class Class1
{
	function sayHi()
	{
		return "Hi from JScript Class";
	}
}


class c2 extends Class1
{
	protected var name : String; //variable of type string

	function get fname() : String //property get (acessor)
	{
		return this.name;
	}

	function set fname(newName : String) //property let (mutator)
	{
		this.name = newName;
	}
}

var o : c2 = new c2;
print(o.sayHi());
o.fname = "Manish";
print(o.fname);