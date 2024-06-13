﻿using Acme.BookStore.Localization;
using System.Text.RegularExpressions;
using Volo.Abp.Authorization.Permissions;
using Volo.Abp.Localization;
using static Acme.BookStore.Permissions.BookStorePermissions;

namespace Acme.BookStore.Permissions;

public class BookStorePermissionDefinitionProvider : PermissionDefinitionProvider
{
    public override void Define(IPermissionDefinitionContext context)
    {
        var bookStoreGroup = context.AddGroup(BookStorePermissions.GroupName, L("Permission:BookStore"));

        var booksPermission = bookStoreGroup.AddPermission(BookStorePermissions.Books.Default, L("Permission:Books"));
        booksPermission.AddChild(BookStorePermissions.Books.Create, L("Permission:Books.Create"));
        booksPermission.AddChild(BookStorePermissions.Books.Edit, L("Permission:Books.Edit"));
        booksPermission.AddChild(BookStorePermissions.Books.Delete, L("Permission:Books.Delete"));


        var authorsPermission = bookStoreGroup.AddPermission(
        BookStorePermissions.Authors.Default, L("Permission:Authors"));
        authorsPermission.AddChild(
            BookStorePermissions.Authors.Create, L("Permission:Authors.Create"));
        authorsPermission.AddChild(
            BookStorePermissions.Authors.Edit, L("Permission:Authors.Edit"));
        authorsPermission.AddChild(
        BookStorePermissions.Authors.Delete, L("Permission:Authors.Delete"));


        var organizationUnitPermission = bookStoreGroup.AddPermission(
            BookStorePermissions.OrganizationUnits.Default, L("Permission:OrganizationUnits"));
        organizationUnitPermission.AddChild(BookStorePermissions.OrganizationUnits.Create, L("Permission:OrganizationUnits.Create"));
        organizationUnitPermission.AddChild(BookStorePermissions.OrganizationUnits.Edit, L("Permission:OrganizationUnits.Edit"));
        organizationUnitPermission.AddChild(BookStorePermissions.OrganizationUnits.Delete, L("Permission:OrganizationUnits.Delete"));


    }

    private static LocalizableString L(string name)
    {
        return LocalizableString.Create<BookStoreResource>(name);
    }
}
