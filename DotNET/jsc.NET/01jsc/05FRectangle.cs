class FRectangle
{
    var Length : double;
    var Height : double;

    function Perimeter() : double
    {
        return (Length + Height) * 2;
    }

    function Area() : double
    {
        return Length * Height;
    }

    function ShowCharacteristics()
    {
        print("Rectangle Characteristics");
        print("Length:     ", Length);
        print("Height:      ", Height);
        print("Perimeter: ", Perimeter());
        print("Area:         ", Area());
    }
}

var Recto : FRectangle = new FRectangle;

Recto.Length = 24.55;
Recto.Height = 20.75;
Recto.ShowCharacteristics();