using System;
using System.Collections.Generic;
using System.Text;

namespace ProductsStore.Common
{
    public static class ModelConstants
    {
        public static class User
        {
            public const int FullNameMaxLength = 50;
        }

        public static class Item
        {
            public const int TitleMaxLength = 120;
            public const int DescriptionMaxLength = 500;
        }


        public static class SubCategory
        {
            public const int NameMaxLength = 50;
        }

        public static class Category
        {
            public const int NameMaxLength = 50;
        }
    }
}
