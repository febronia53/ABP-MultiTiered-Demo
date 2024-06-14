$(function () {
    var l = abp.localization.getResource('BookStore');
    var createModal = new abp.ModalManager(abp.appPath + 'OrganizationUnits/CreateModal');
    var editModal = new abp.ModalManager(abp.appPath + 'OrganizationUnits/EditModal');

    var dataTable = $('#OrganizationUnitsTable').DataTable(
        abp.libs.datatables.normalizeConfiguration({
            serverSide: true,
            paging: true,
            order: [[1, "asc"]],
            searching: false,
            scrollX: true,
            ajax: abp.libs.datatables.createAjax(acme.bookStore.controllers.organizationUnits.organizationUnit.getOrganizationUnitsList),
            columnDefs: [
                {
                    title: l('Actions'),
                    rowAction: {
                        items:
                            [
                                {
                                    text: l('Edit'),
                                    visible:
                                        abp.auth.isGranted('BookStore.OrganizationUnits.Edit'),
                                    action: function (data) {
                                        editModal.open({ id: data.record.id });
                                    }
                                },
                                {
                                    text: l('Delete'),
                                    visible:
                                        abp.auth.isGranted('BookStore.OrganizationUnits.Delete'),
                                    confirmMessage: function (data) {
                                        return l(
                                            'OrganizationUnitDeletionConfirmationMessage',
                                            data.record.name
                                        );
                                    },
                                    action: function (data) {
                                        acme.bookStore.controllers.organizationUnits.organizationUnit
                                            .deleteOrganization(data.record.id)
                                            .then(function () {
                                                abp.notify.info(
                                                    l('SuccessfullyDeleted')
                                                );
                                                dataTable.ajax.reload();
                                            });
                                    }
                                }
                            ]
                    }
                },
                {
                    title: l('Name'),
                    data: "displayName"
                },
                {
                    title: l('Code'),
                    data: "code"
                    }
                
            ]
        })
    );

    var createModal = new abp.ModalManager(abp.appPath + 'OrganizationUnits/CreateModal');

    createModal.onResult(function () {
        dataTable.ajax.reload();
    });
    editModal.onResult(function () {
        dataTable.ajax.reload();
    });

    $('#NewOrganizationUnitButton').click(function (e) {
        e.preventDefault();
        createModal.open();
    });


});
