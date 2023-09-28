# Exercice :  Extends and Implements

In this exercice, we saw that a class can implement more than one interface. In the concluding example, we will go one step further by letting the same child class inherit from both a parent class and from two interfaces.

1. Create a **User** class with a protected **username** attribut and methods that can set and get the **username**.
2. Create a function IsReading that randomly returns true or false
3. Create a function ToString that returns **username** is reading or **username** is not reading
4. Create an Author interface with the following abstract methods that can give the user an array of authorship privileges. The first method is setAuthorPrivileges(), and it gets a parameter of $array, and the second method is getAuthorPrivileges().
5. Create an Editor interface with methods to set and get the editor's privileges.
6. Create an AuthorEditor class that extends both the User class, and implements the Author and the Editor interfaces.
   observe the error message.
7. Create in the AuthorEditor class the **methods** that it should implement, and the **properties** that these methods force us to add to the class.
   For example, in order to implement the public method setAuthorPrivileges(), we must add to our class a property that holds the array of authorship privileges, and name it $authorPrivilegesArray accordingly.
8. Now, let's create an object with the name of $user1 from the class AuthorEditor, and set its username to "Balthazar".
9. Set in the $user1 object an array of authorship privileges, with the following privileges: "write text", "add punctuation".
10. Set in the $user1 object an array with the following editorial privileges: "edit text", "edit punctuation".
11. Add a function ToString in AuthorEditor class that returns parent's string and privileges like that "Balthazar is reading.
    Balthazar has the following privileges: write text, add punctuation, edit text, edit punctuation."
