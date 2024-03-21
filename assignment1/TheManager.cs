using System;
using System.Collections;
using TheClass;
using System.IO;

namespace TheManager {
    public class Manager {
        ArrayList classes;
        Dictionary<string, int> checkBox;
        Dictionary<string, Class> infoClass;
        public void init(int N) {
            classes = new ArrayList();
            checkBox = new Dictionary<string, int>();
            infoClass = new Dictionary<string, Class>();
            string filePath1 = "studentList.txt";

            // try
            // {
            //     // Mở tệp để đọc dữ liệu
            //     using (StreamReader reader = new StreamReader(filePath1))
            //     {
            //         string line;
            //         // Đọc từng dòng cho đến khi hết tệp
            //         int cnt = 0;
            //         while ((line = reader.ReadLine()) != null)
            //         {
            //             // Xử lý dòng vừa đọc ở đây
            //             TheStudent.Student student = new TheStudent.Student();
            //             student.setID(line);
            //             line = reader.ReadLine();
            //             student.setName(line);
            //             line = reader.ReadLine();
            //             student.setIDClass(line);
            //             line = reader.ReadLine();

            //             double number;
            //             if (double.TryParse(line, out number))
            //             {
            //                 // Parsing successful
            //                 student.setAverScore((double)(number));                
            //             }
            //             if (!checkBox.ContainsKey(student.getIDClass())) {
            //                 ArrayList newClass = new ArrayList();
            //                 classes.Add(newClass);
            //                 checkBox[student.getIDClass()] = cnt++;
            //             } 
            //             ((ArrayList)classes[checkBox[student.getIDClass()]]).Add(student);
            //         }
            //     }
            // }
            // catch (Exception ex)
            // {
            //     Console.WriteLine("An error occurred: " + ex.Message);
            // }
            StreamReader reader1 = new StreamReader(filePath1);
            int cnt = 0;
            int i = 0; // Declare and initialize i here
            for (i = 0; i < N; ++i) {
                TheStudent.Student student = new TheStudent.Student();
                student.setID(reader1.ReadLine());
                student.setName(reader1.ReadLine());
                student.setIDClass(reader1.ReadLine());
                double number;
                if (double.TryParse(reader1.ReadLine(), out number))
                {
                    // Parsing successful
                    student.setAverScore((double)(number));                
                }
                if (!checkBox.ContainsKey(student.getIDClass())) {
                    ArrayList newClass = new ArrayList();
                    classes.Add(newClass);
                    checkBox[student.getIDClass()] = cnt++;
                } 
                ((ArrayList)classes[checkBox[student.getIDClass()]]).Add(student);
            }

            string filePath = "classList.txt";

            try
            {
                // Mở tệp để đọc dữ liệu
                using (StreamReader reader = new StreamReader(filePath))
                {
                    string line;
                    // Đọc từng dòng cho đến khi hết tệp
                    while ((line = reader.ReadLine()) != null)
                    {
                        // Xử lý dòng vừa đọc ở đây
                        Class currentClass = new Class();
                        infoClass[line] = currentClass;
                        currentClass.setID(line);
                        line = reader.ReadLine();
                        currentClass.setName(line);
                        line = reader.ReadLine();
                        currentClass.setFaculty(line);
                        ++i;
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("An error occurred: " + ex.Message);
            }
        }
        public void gameShow() {
            Console.WriteLine("type a IDClass\n");
            string res = Console.ReadLine();
            Console.WriteLine("What do you wanna\n");
            Console.WriteLine("Scholarship: type 1\n");
            Console.WriteLine("member: type 2\n");
            Console.WriteLine("rest for empty\n");
            string ans = Console.ReadLine();
            if (ans == "2") this.show(res);
            else if (ans == "1") this.showScholarship(res);
            else {
                Console.WriteLine("Bye\n");
            }
        }
        public void showClass() {
            Console.WriteLine("Danh Sach cac ma lop\n");
            foreach (KeyValuePair<string, Class> kvp in infoClass)
            {
                string classID = kvp.Key;
                Class classInfo = kvp.Value;
                
                // Thực hiện các thao tác với classID và classInfo ở đây
                // Console.WriteLine("Class ID: " + classID);
                Console.WriteLine("Class Info: ");
                classInfo.show();
            }

        }
        public void show() {
            Console.WriteLine("Danh Sach hoc sinh cac lop\n");
            int n = classes.Count;
            if (n == 0) {
                Console.WriteLine("Empty\n");
            }
            for (int i = 0; i < n; ++i) {
                ArrayList currentClass = (ArrayList)classes[i];
                currentClass.Sort(new Manager.StudentComparer()); // Sort students within the class
                int m = currentClass.Count;
                for (int j = 0; j < m; ++j) {
                    TheStudent.Student currentStudent = (TheStudent.Student)currentClass[j];
                    currentStudent.show();
                }
            }   
        }
        public void showScholarship(string IDClass) {
            Console.WriteLine("Danh Sach Co Hoc Bong\n");
            // Retrieve information about the specified class
            if (!infoClass.ContainsKey(IDClass)) {
                Console.WriteLine("hmm\n");
                return ;
            }
            Class myClass = infoClass[IDClass];
            myClass.show();

            // Retrieve students of the specified class
            ArrayList myStudents = (ArrayList)classes[checkBox[IDClass]];
            myStudents.Sort(new Manager.StudentComparer());
            myStudents.Reverse();
            // Display information about each student in the class
            int n = myStudents.Count;
            const double scholarshipScore = 8.0;
            const double percent = 0.1;
            //myStudents.Reverse();
            if (n == 0) {
                Console.WriteLine("Empty\n");
            }
            for (int i = 0; i < n * percent; ++i) {
                TheStudent.Student currentStudent = (TheStudent.Student)myStudents[i];
                // if (currentStudent.getAverScore() < scholarshipScore) {
                //     break;
                // }
                currentStudent.show();
            }
        }
        public void show(string IDClass) {
            // Retrieve information about the specified class
            if (!infoClass.ContainsKey(IDClass)) {
                Console.WriteLine("hmm\n");
                return ;
            }
            Class myClass = infoClass[IDClass];
            myClass.show();

            // Retrieve students of the specified class
            ArrayList myStudents = (ArrayList)classes[checkBox[IDClass]];
            //myStudents.Sort(new Manager.StudentComparer());
            //myStudents.Reverse();
            // Display information about each student in the class
            int n = myStudents.Count;
            //myStudents.Reverse();
            if (n == 0) {
                Console.WriteLine("Empty\n");
            }
            for (int i = 0; i < n; ++i) {
                TheStudent.Student currentStudent = (TheStudent.Student)myStudents[i];
                // if (currentStudent.getAverScore() < scholarshipScore) {
                //     break;
                // }
                currentStudent.show();
            }
        }

        // Custom comparer class to sort students by average score
        public class StudentComparer : IComparer {
            public int Compare(object x, object y) {
                TheStudent.Student student1 = (TheStudent.Student)x;
                TheStudent.Student student2 = (TheStudent.Student)y;
                return student1.getAverScore().CompareTo(student2.getAverScore());
            }
        }
    }
}
