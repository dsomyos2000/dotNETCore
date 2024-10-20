namespace SampleLibrary {
  public class Person
  {
    private string name; // field
    public string Name   // property
    {
      get { return "["+name+"]"; }   // get method
      set { name = value; }  // set method
    }
  }
}