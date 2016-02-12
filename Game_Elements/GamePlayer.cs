using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game_Elements
{
    public class GamePlayer
    {
        public GamePlayer(int index)
        {
            this.index = index;
            create_dobber_win();
        }

        private void create_dobber_win()
        {
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i<4; ++i)
            {
                sb.Append(index.ToString());
            }
            dobber_win = sb.ToString();
        }

        private void write_with_colour(string message)
        {
            if (!string.IsNullOrEmpty(message))
            {
                string[] array = message.Split('%');

                if (array.Length > 2)
                {
                    Console.Write(array[0]);
                    Console.BackgroundColor = (index == 1) ? ConsoleColor.Blue : ConsoleColor.Red;
                    Console.Write(array[1]);
                    Console.BackgroundColor = ConsoleColor.Black;
                    Console.Write(array[2]);
                }
                else
                    Console.Write(message);
            }
        }

        private bool is_human_comp(string answer)
        {
            if (answer.ToUpper().Equals("H"))
            {
                human = true;
                return true;
            }
            else if (answer.ToUpper().Equals("C"))
            {
                human = false;
                return true;
            }
            return false;
        }

        public void pick_player()
        {
            bool flag = false;
            string answer = "";
            
            string question = "Player %" + index.ToString() + "%, human or computer { h / c}: ";
            do
            {
                Console.Clear();
                write_with_colour(question);
                answer = Console.ReadLine();

                flag = is_human_comp(answer);
                
                if(!flag)
                    question = "Error: Player %" + index.ToString() + "%, human or computer { h / c}: "; 

            } while (!flag);
            
        }

        private bool get_position_from_user(ref int location)
        {
            string answer = "";
            write_with_colour("Player: %" + index.ToString() + "% Please enter the column you would like to drop a dobber in: ");
            answer = Console.ReadLine();

            if (!Int32.TryParse(answer, out location))
            {
                Console.WriteLine("Error with what you enterd: 1-7 please");
                reset_cursor();
            }
            else
                return true;

            return false;
        }

        private void human_go(ref GameBoard gameboard)
        {
            int pos = -1;
            bool flag = false;

            get_cursor_position();

            do
            {
                flag = get_position_from_user(ref pos);
                if (flag)
                {
                    if (!gameboard.drop_dobber(pos - 1, dobber()))
                    {
                        reset_cursor();
                        Console.WriteLine("Error with column, please select a new column");
                        flag = false;
                    }
                }
            } while (!flag);
        }

        private void ai_go(ref GameBoard gameboard)
        {
            bool find_position = true;
            Random r = new Random(DateTime.Now.Millisecond);
            int computer_position = 0;

            while (find_position)
            {
                computer_position = r.Next(7);
                if (gameboard.drop_dobber(computer_position, dobber()))
                    find_position = false;
            }
        }

        public void go(ref GameBoard gameboard)
        {
            if (human)
                human_go(ref gameboard);
            else
                ai_go(ref gameboard);   
        }

        public string dobber()
        {
            return index.ToString();
        }

        public string get_dobber_win()
        {
            return dobber_win;
        }
        
        private void get_cursor_position()
        {
            origRow = Console.CursorTop;
            origCol = Console.CursorLeft;
        }

        private void reset_cursor()
        {
            Console.SetCursorPosition(origCol, origRow);
            Console.Write(new string(' ', Console.WindowWidth));
            Console.Write(new string(' ', Console.WindowWidth));
            Console.SetCursorPosition(origCol, origRow);
        }

        private bool human;
        private int index;
        private string dobber_win;
        protected int origRow;
        protected int origCol;
    }
}
