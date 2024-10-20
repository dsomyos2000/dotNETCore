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
}