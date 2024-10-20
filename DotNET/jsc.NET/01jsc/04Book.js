class Book
{
    var Title     : String;
    var Author    : String;
    var Pages     : int;
    var CoverType : char;
}

var BrandNew : Book;

BrandNew = new Book;

BrandNew.Title     = "Webber Databases With JScript .NET";
BrandNew.Author    = "Catherine Mamfourh";
BrandNew.Pages     = 1225;
BrandNew.CoverType = 'H';

print("Book Characteristics");
print("Title:  ", BrandNew.Title);
print("Author: ", BrandNew.Author);
print("Pages:  ", BrandNew.Pages);
print("Cover:  ", BrandNew.CoverType);