# Basic

Write a C# console application that, given a sequence of "instructions" (script), should read each line and execute the command. 
When all the lines are "executed" the program is considered complete. 
To keep it simple, the script can come from a hard-coded string. 

## Example of a script

```
int x
int y
set x 10
set y 20
add x y
sub y 5
print x
print y
```

The output should be `30` and then (on a separate line) `15`. 

## Instructions 

* `int x` : Defines a new variable `x` that can hold an integer. A variable name is restricted to letters (no other characters like spaces, numbers, etc).
* `set x 10` : Changes the values of variable `x` to hold the constant `10`. The `set` instruction expects only constant `int`s as the second parameter.
* `add x y` : `x = x + y` or `add x 123` -> `x + x + 123`. The `add` instruction expects a variable for the first parameter and a variable or a constant for the second parameter.
* `sub y 5` : `y = y -5` Similar to the "add" instruction, except that it performs a subtraction.
* `print x` : prints the value for `x` to the console and then goes to the next line. The `print` instruction expects only a variable as the second parameter.
