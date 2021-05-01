using System;

var myStruct = new MyStruct("something");

PassValueByReference(ref myStruct);

void PassValueByReference(ref MyStruct myStruct) {
    myStruct = new MyStruct();
    Console.WriteLine(myStruct.Title);
}

public struct MyStruct {
    public MyStruct(string title) {
        Title = title;
    }
    
    public string Title { get; set;  }
    // and lots of other properties
}