$(function () {

    var l = abp.localization.getResource('kmgiasoc');

    var service = kmgiasoc.deals.deal;
    var createModal = new abp.ModalManager(abp.appPath + 'Deals/Deal/CreateModal');
    var editModal = new abp.ModalManager(abp.appPath + 'Deals/Deal/EditModal');

    var dataTable = $('#DealTable').DataTable(abp.libs.datatables.normalizeConfiguration({
        processing: true,
        serverSide: true,
        paging: true,
        searching: false,
        autoWidth: false,
        scrollCollapse: true,
        order: [[0, "asc"]],
        ajax: abp.libs.datatables.createAjax(service.getList),
        columnDefs: [
            {
                rowAction: {
                    items:
                        [
                            {
                                text: l('Edit'),
                                visible: abp.auth.isGranted('kmgiasoc.Deal.Update'),
                                action: function (data) {
                                    editModal.open({ id: data.record.id });
                                }
                            },
                            {
                                text: l('Delete'),
                                visible: abp.auth.isGranted('kmgiasoc.Deal.Delete'),
                                confirmMessage: function (data) {
                                    return l('DealDeletionConfirmationMessage', data.record.id);
                                },
                                action: function (data) {
                                    service.delete(data.record.id)
                                        .then(function () {
                                            abp.notify.info(l('SuccessfullyDeleted'));
                                            dataTable.ajax.reload();
                                        });
                                }
                            }
                        ]
                }
            },
            {
                title: l('DealTitle'),
                data: "title"
            },
            {
                title: l('DealDescription'),
                data: "description"
            },
            {
                title: l('DealLink'),
                data: "link"
            },
            {
                title: l('DealDomainLink'),
                data: "domainLink"
            },
            {
                title: l('DealImage'),
                data: "image"
            },
            {
                title: l('DealDealCategoryId'),
                data: "dealCategoryId"
            },
            {
                title: l('DealDealPriority'),
                data: "dealPriority"
            },
            {
                title: l('DealPrice'),
                data: "price"
            },
            {
                title: l('DealPricePromo'),
                data: "pricePromo"
            },
            {
                title: l('DealFreeShipping'),
                data: "freeShipping"
            },
            {
                title: l('DealPriceShipping'),
                data: "priceShipping"
            },
            {
                title: l('DealCodePromo'),
                data: "codePromo"
            },
            {
                title: l('DealBeginPromo'),
                data: "beginPromo"
            },
            {
                title: l('DealEndPromo'),
                data: "endPromo"
            },
            {
                title: l('DealCityId'),
                data: "cityId"
            },
            {
                title: l('DealCity'),
                data: "city"
            },
            {
                title: l('DealLocalShop'),
                data: "localShop"
            },
            {
                title: l('DealPublishDate'),
                data: "publishDate"
            },
            {
                title: l('DealModifiedDate'),
                data: "modifiedDate"
            },
        ]
    }));

    createModal.onResult(function () {
        dataTable.ajax.reload();
    });

    editModal.onResult(function () {
        dataTable.ajax.reload();
    });

    $('#NewDealButton').click(function (e) {
        e.preventDefault();
        createModal.open();
    });


    $('#UploadFileDto_File').change(function () {
        const file = this.files[0];
        console.log(file);
        if (file) {
            let reader = new FileReader();
            reader.onload = function (event) {
                $('#imgPreview').show();
                $('#imgPreview').attr('src', event.target.result);
            }
            reader.readAsDataURL(file);
        }
    });
});
