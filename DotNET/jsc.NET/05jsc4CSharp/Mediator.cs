namespace montego.webserving.applet
{
using ServerPush;
using System;

/* Trying To Inherit JS
* package ServerPush
* {
* public class jsServerPush
* {
* */
public class Mediator : jsServerPush
{
public Mediator()
{
System.String[] args = new System.String
[3];
args[0]= "Interface";
args[1]= "Being";
args[2]= "Called";

lib_setdata( args[0], args[1], args[2] );
}


public static void Main(System.String[]
args)
{
Mediator f = new Mediator();
}


}
}