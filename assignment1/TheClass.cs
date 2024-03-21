using System;
namespace TheClass {
    public class Class {
        string ID;
        string name;
        string faculty;
        public void setID(string ID) {
            this.ID = ID;
        }
        public void setName(string name) {
            this.name = name;
        }
        public void setFaculty(string faculty) {
            this.faculty = faculty;
        }
        string getID() {
            return this.ID;
        }
        string getName() {
            return this.name;
        }
        string getFaculty() {
            return this.faculty;
        }
        public void show() {
            Console.WriteLine("Class ID: " + this.getID());
            Console.WriteLine("Class Name: " + this.getName());
            Console.WriteLine("Faculty: " + this.getFaculty());
            Console.WriteLine();
        }
    }
}