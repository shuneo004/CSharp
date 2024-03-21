using System;
using System.Collections;

namespace TheStudent {
    public class Student {
        string ID;
        string name;
        string IDClass;
        double averScore;
        public void setID(string ID) {
            this.ID = ID;
        }
        public void setName(string name) {
            this.name = name;
        }
        public void setIDClass(string IDClass) {
            this.IDClass = IDClass;
        }
        public void setAverScore(double averScore) {
            this.averScore = averScore;
        }
        public string getID() {
            return this.ID;
        }
        public string getIDClass() {
            return this.IDClass;
        }
        public string getName() {
            return this.name;
        }
        public double getAverScore() {
            return this.averScore;
        }
        public void show() {
            Console.WriteLine("Student ID: " + this.getID());
            Console.WriteLine("Student Name: " + this.getName());
            Console.WriteLine("Student Class ID: " + this.getIDClass());
            Console.WriteLine("Student Average Score: " + this.getAverScore());
            Console.WriteLine();
        }

    }
}