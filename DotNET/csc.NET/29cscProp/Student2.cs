//class Student { public int Age { get; private set; } }
class Student
{
  private int _age;

  public int GetAge()
  {
    return _age;
  }

  private void SetAge(int age)
  {
    _age = age;
  }
}