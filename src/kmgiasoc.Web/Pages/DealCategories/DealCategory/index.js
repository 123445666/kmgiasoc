$(function () {

    var l = abp.localization.getResource('kmgiasoc');

    var service = kmgiasoc.dealCategories.dealCategory;
    var createModal = new abp.ModalManager(abp.appPath + 'DealCategories/DealCategory/CreateModal');
    var editModal = new abp.ModalManager(abp.appPath + 'DealCategories/DealCategory/EditModal');

    var dataTable = $('#DealCategoryTable').DataTable(abp.libs.datatables.normalizeConfiguration({
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
                                visible: abp.auth.isGranted('kmgiasoc.DealCategory.Update'),
                                action: function (data) {
                                    editModal.open({ id: data.record.id });
                                }
                            },
                            {
                                text: l('Delete'),
                                visible: abp.auth.isGranted('kmgiasoc.DealCategory.Delete'),
                                confirmMessage: function (data) {
                                    return l('DealCategoryDeletionConfirmationMessage', data.record.id);
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
                title: l('DealCategoryName'),
                data: "name"
            },
            {
                title: l('DealCategoryParent'),
                data: "parent"
            },
            {
                title: l('DealCategoryDescription'),
                data: "description"
            },
            {
                title: l('DealCategoryCatOrder'),
                data: "catOrder"
            },
            {
                title: l('DealCategoryPublishDate'),
                data: "publishDate"
            },
            {
                title: l('DealCategoryModifiedDate'),
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

    $('#NewDealCategoryButton').click(function (e) {
        e.preventDefault();
        createModal.open();
    });
});
