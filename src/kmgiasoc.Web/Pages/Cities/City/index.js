$(function () {

    var l = abp.localization.getResource('kmgiasoc');

    var service = kmgiasoc.cities.city;
    var createModal = new abp.ModalManager(abp.appPath + 'Cities/City/CreateModal');
    var editModal = new abp.ModalManager(abp.appPath + 'Cities/City/EditModal');

    var dataTable = $('#CityTable').DataTable(abp.libs.datatables.normalizeConfiguration({
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
                                visible: abp.auth.isGranted('kmgiasoc.City.Update'),
                                action: function (data) {
                                    editModal.open({ id: data.record.id });
                                }
                            },
                            {
                                text: l('Delete'),
                                visible: abp.auth.isGranted('kmgiasoc.City.Delete'),
                                confirmMessage: function (data) {
                                    return l('CityDeletionConfirmationMessage', data.record.id);
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
                title: l('CityCountryId'),
                data: "countryId"
            },
            {
                title: l('CityCountry'),
                data: "country"
            },
            {
                title: l('CityName'),
                data: "name"
            },
            {
                title: l('CityOrderCity'),
                data: "orderCity"
            },
        ]
    }));

    createModal.onResult(function () {
        dataTable.ajax.reload();
    });

    editModal.onResult(function () {
        dataTable.ajax.reload();
    });

    $('#NewCityButton').click(function (e) {
        e.preventDefault();
        createModal.open();
    });
});
