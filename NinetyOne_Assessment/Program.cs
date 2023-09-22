namespace NinetyOne_Assessment
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string csv = File.ReadAllText("C:\\Users\\waram\\source\\repos\\NineTyOne\\TestData.csv");

            //Split into lines
            string[] rows = csv.Split(new char[] { '\n' }, StringSplitOptions.RemoveEmptyEntries);

            List<Student> students = new List<Student>();

            //Load students list. Start from 2nd row to skip headers.
            for (int row = 1; row < rows.Length; row++)
            {
                string[] line_r = rows[row].Split(',');
                students.Add(new Student
                {
                    FirstName = line_r[0],
                    SecondName = line_r[1],
                    Score = int.Parse(line_r[2])
                });
            }

            int maxScore = students.Max(_ => _.Score);
            var topScorers = students.FindAll(_ => _.Score == maxScore).OrderBy(_=> _.FirstName).ToList();

            foreach (var item in topScorers)
            {
                Console.WriteLine($"{item.FirstName} {item.SecondName}");
            }
            Console.WriteLine($"Score: {maxScore}");
            Console.ReadLine();
        }
    }
}