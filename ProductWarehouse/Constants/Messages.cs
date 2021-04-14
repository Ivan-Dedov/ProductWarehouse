namespace ProductWarehouse
{
    /// <summary>
    /// Contains the messages that the user will see if they encounter an error.
    /// </summary>
    public static class Messages
    {
        public const string FileOpenErrorTitle =
            "Could Not Open File";

        public const string FixErrorsCaption =
            "Cannot Create Item";
        public const string FixErrorsText = 
            "Please fix all errors in the Item Setup menu and retry.";

        public const string ForbiddenActionCaption =
            "Could Not Complete Action";
        public const string CouldNotDeleteItemText =
            "Cannot delete a Section that contains other items.";
        public const string CouldNotAddProductToNoSectionText =
            "Cannot add Product to Warehouse directly. Please select a Section.";
        public const string CouldNotAddItemToProductText =
            "Cannot add Item to a Product. Please select a Section.";

        public const string UnexpectedErrorCaption =
            "Unexpected Error";

        public const string ConfirmSaveCaption =
            "Save Warehouse";
        public const string ConfirmSaveText =
            "Would you like to save the Warehouse?";
        public const string ConfirmSaveBeforeCreatingNewText =
            "Creating a random Warehouse will erase the current Warehouse. " +
            "Would you like to save the Warehouse?";
    }
}