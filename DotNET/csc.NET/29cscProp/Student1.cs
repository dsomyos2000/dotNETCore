//class Student { public int Age { get; set; } }
class Student
{
  private int _age;

  public int GetAge()
  {
    return _age;
  }

  public void SetAge(int age)
  {
    _age = age;
  }
}