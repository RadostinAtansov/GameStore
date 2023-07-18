namespace GameStore.Data
{
    public class DataValidation
    {
        public class GameDataValidation
        {
            public const string MessageGameName = "Name is between 3 and 20 char symbols";
            public const string MessageRequiredGameName = "Name is required";
            public const int MinLengthGameName = 3;
            public const int MaxLengthGameName = 20;

            public const string MessageGameDescription = "Description is between 15 and 150 char symbols";
            public const string MessageRequiredDescriptionName = "Description is required";
            public const int MinLengthGameDescription = 15;
            public const int MaxLengthGameDescription = 150;

            public const string MessageGameCompany = "Company is between 3 and 20 char symbols";
            public const string MessageRequiredCompanyName = "Company is required";
            public const int MinLengthGameCompany = 3;
            public const int MaxLengthGameCompany = 20;
            
            public const string MessageRequiredPriceName = "Price is required";
            public const string MinPrice = "0";
            public const string MaxPrice = "9999999";

            public const string MessageRequiredCategoryName = "Category is required";
        }

        public class UserDataValidation
        {
            public const string MessageUsername = "Username is between 3 and 20 char symbols";
            public const string MessageRequiredUsername = "Username is required";
            public const int MinLengthUsername = 3;
            public const int MaxLengthUsername = 20;
        }

        public class CommentDataValidation
        {
            public const string MessageTitleRequired = "Title is Required";
            public const string MessageTitleComment = "Title is between 10 and 50 char symbols";
            public const int MinLengthComment = 10;
            public const int MaxLengthComment = 50;

            public const string MessageTextRequired = "Text is Required";
            public const string MessageTextComment = "Text is between 10 and 50 char symbols";
            public const int MinLengthText = 25;
            public const int MaxLengthText = 500;
        }

        public class StatisticDataValidation
        {
            public const string MinNumber = "0";
            public const string MaxNumber = "2000000000";

            public const string MessageWhoBoughtThisGameRequired = "WhoBoughtThisGame is Required";
            public const string MessageWhoBoughtThisGame = "WhoBoughtThisGame is between 5 and 50 char symbols";
            public const int MinLengthWhoBoughtThisGame = 5;
            public const int MaxLengthWhoBoughtThisGame = 50;
        }

        public class ImageDataValidation
        {
            public const string MessageRequireImage = "Image name Required";
            public const string MessageLengthName = "Image name is between 3 to 20 char symbols";
            public const int MinLengthName = 3;
            public const int MaxLengthName= 20;

            public const string MessageImageRequire = "Require image";
        }
    }
}