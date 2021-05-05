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

        public const string EmptyFullNameCaption =
            "Full Name is Empty";
        public const string EmptyFullNameText =
            "Full name cannot be empty!";
        public const string IncorrectPhoneCaption =
            "Incorrect Phone Number";
        public const string IncorrectPhoneText =
            "Phone number must be 11 characters long, only numbers are allowed. For example: 80006969420";
        public const string EmptyAddressCaption =
            "Address is Empty";
        public const string EmptyAddressText =
            "Address cannot be empty!";
        public const string EmptyEmailCaption =
            "E-mail is Empty";
        public const string EmptyEmailText =
            "E-mail cannot be empty!";
        public const string InvalidPasswordCaption =
            "Invalid Password";
        public const string InvalidPasswordText =
            "Password must be 6 - 20 characters long. Only letters A-Z, a-z, numbers 0-9 and " +
            "the following symbols are allowed: . , _ + - * & # % ! ? ( ) [ ]";
        public const string AllowedPasswordChars =
            "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789.,_+-*&#%!?()[]";

        public const string SignUpFailedCaption =
            "Could Not Sign Up";

        public const string LoginFailedCaption =
            "Login Failed";
        public const string LoginFailedText =
            "Incorrect login or password. Please try again or sign up.";

        public const string ProductAddingFailedCaption =
            "Could Not Add Product";
        public const string ProductAddingFailedText =
            "Cannot add 0 products to cart.";

        public const string EmptyCartCaption =
            "Empty Cart";
        public const string EmptyCartText =
            "The cart is empty. Cannot create Order.";

        public const string CannotPayCaption =
            "Payment Failed";
        public const string CannotPayText =
            "You can only pay for a processed order. This order has not been processed yet or is already " +
            "paid for.";

        public const string CouldNotDeserializeCaption =
            "Could Not Deserialize Clients";
        public const string CouldNotDeserializeText =
            "The client database file is missing or corrupted. No customers could be loaded.";

        public const string ActionNotAllowedCaption =
            "Action Forbidden";
        public const string ActionNotAllowedText =
            "Customers cannot perform this action. Log in as a Salesman to get access to this action.";
    }
}