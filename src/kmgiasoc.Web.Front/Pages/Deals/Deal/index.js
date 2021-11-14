$(function () {

    var l = abp.localization.getResource("CmsKit");

    var $formCreate = $('#form-deal-create');
    var $shortDescription = $('#ViewModel_ShortDescription');
    var $coverImage = $('#ViewModel_CoverImageMediaId');
    var $buttonSubmit = $('#AddDealButton');
    var $pageContentInput = $('#ViewModel_Description');
    var $fileInput = $('#DealUploadFileDto_File');

    var UPPY_FILE_ID = "uppy-upload-file";

    $formCreate.data('validator').settings.ignore = ":hidden, [contenteditable='true']:not([name]), .tui-popup-wrapper";

    $formCreate.on('submit', function (e) {
        e.preventDefault();

        if ($formCreate.valid()) {

            $formCreate.ajaxSubmit({
                success: function (result) {
                        finishSaving();
                },
                error: function (result) {
                    abp.notify.error(result.responseJSON.error.message);
                    abp.ui.clearBusy();
                }
            });
        }
        else {
            abp.ui.clearBusy();
        }
    });

    $buttonSubmit.click(function (e) {
        e.preventDefault();
        submitCoverImage();
    });

    function getUppyHeaders() {
        var headers = {};
        headers[abp.security.antiForgery.tokenHeaderName] = abp.security.antiForgery.getToken();

        return headers;
    }

    function submitCoverImage() {
        abp.ui.setBusy();

        var UPPY_OPTIONS = {
            endpoint: fileUploadUri,
            formData: true,
            fieldName: "file",
            method: "post",
            headers: getUppyHeaders()
        };

        var UPPY = Uppy.Core().use(Uppy.XHRUpload, UPPY_OPTIONS);

        UPPY.reset();

        var file = $fileInput[0].files[0];

        if (file) {

            UPPY.addFile({
                id: UPPY_FILE_ID,
                name: file.name, // file name
                type: file.type, // file type
                data: file, // file
            });

            UPPY.upload().then((result) => {
                if (result.failed.length > 0) {
                    abp.message.error(l("UploadFailedMessage"));
                } else {
                    $coverImage.val(result.successful[0].response.body.id);

                    $formCreate.submit();
                }
            });
        }
        else {
            $formCreate.submit();
        }
    }

    function finishSaving() {
        abp.notify.success(l('SuccessfullySaved'));
        abp.ui.clearBusy();
        location.href = "/deals/deal/create";
    }

    var shorDescriptionEdited = false;

    function reflectContentChanges(htmlContent) {
        if (shorDescriptionEdited) {
            return;
        }

        var plainValue = jQuery('<div>').html(htmlContent).text().replace(/\n/g, ' ').substring(0, 120);

        $shortDescription.val(plainValue);
    }

    $shortDescription.on('change', function () {
        shorDescriptionEdited = true;
    });

    // -----------------------------------
    var fileUploadUri = "/api/deal-kit-front/media/deal";
    var fileUriPrefix = "/api/cms-kit/media/";

    initAllEditors();

    function initAllEditors() {
        $('.content-editor').each(function (i, item) {
            initEditor(item);
        });
    }

    function initEditor(element) {
        var $editorContainer = $(element);
        var inputName = $editorContainer.data('input-id');
        var placeholder = $editorContainer.data('placeholder');
        var $editorInput = $('#' + inputName);
        var initialValue = $editorInput.val();

        var editor = new toastui.Editor({
            el: $editorContainer[0],
            usageStatistics: false,
            useCommandShortcut: true,
            initialValue: initialValue,
            previewStyle: 'tab',
            height: "100%",
            minHeight: "25em",
            initialEditType: 'markdown',
            language: $editorContainer.data("language"),
            placeholder: placeholder,
            hooks: {
                addImageBlobHook: uploadFile,
            },
            events: {
                change: function (_val) {
                    $editorInput.val(editor.getMarkdown());
                    $editorInput.trigger("change");
                    reflectContentChanges(editor.getHtml());
                }
            }
        });
    }

    function uploadFile(blob, callback, source) {
        var UPPY_OPTIONS = {
            endpoint: fileUploadUri,
            formData: true,
            fieldName: "file",
            method: "post",
            headers: getUppyHeaders()
        };

        var UPPY = Uppy.Core().use(Uppy.XHRUpload, UPPY_OPTIONS);

        UPPY.reset();

        UPPY.addFile({
            id: "content-file",
            name: blob.name,
            type: blob.type,
            data: blob,
        });

        UPPY.upload().then((result) => {
            if (result.failed.length > 0) {
                abp.message.error("File upload failed");
            } else {
                var mediaDto = result.successful[0].response.body;
                var fileUrl = (fileUriPrefix + mediaDto.id);

                callback(fileUrl, mediaDto.name);
            }
        });
    }
});