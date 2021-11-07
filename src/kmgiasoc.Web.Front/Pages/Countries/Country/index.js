$(function () {

    var l = abp.localization.getResource('kmgiasoc');

    var service = kmgiasoc.countries.country;
    var createModal = new abp.ModalManager(abp.appPath + 'Countries/Country/CreateModal');
    var editModal = new abp.ModalManager(abp.appPath + 'Countries/Country/EditModal');

    var dataTable = $('#CountryTable').DataTable(abp.libs.datatables.normalizeConfiguration({
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
                                visible: abp.auth.isGranted('kmgiasoc.Country.Update'),
                                action: function (data) {
                                    editModal.open({ id: data.record.id });
                                }
                            },
                            {
                                text: l('Delete'),
                                visible: abp.auth.isGranted('kmgiasoc.Country.Delete'),
                                confirmMessage: function (data) {
                                    return l('CountryDeletionConfirmationMessage', data.record.id);
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
                title: l('CountryName'),
                data: "name"
            },
            {
                title: l('CountryFlag'),
                data: "flag"
            },
            {
                title: l('CountryOrderCountry'),
                data: "orderCountry"
            },
        ]
    }));

    createModal.onResult(function () {
        dataTable.ajax.reload();
    });

    editModal.onResult(function () {
        dataTable.ajax.reload();
    });

    $('#NewCountryButton').click(function (e) {
        e.preventDefault();
        createModal.open();
    });
});
