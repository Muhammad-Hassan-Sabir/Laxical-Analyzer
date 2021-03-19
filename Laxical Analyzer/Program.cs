using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Text.RegularExpressions;

namespace Laxical_Analyzer
{
    class Program
    {
        static void Main(string[] args)
        {
           


            Dictionary<char, char> intvalues = new System.Collections.Generic.Dictionary<char, char>();
            intvalues.Add('1', '1');
            intvalues.Add('2', '2');
            intvalues.Add('3', '3');
            intvalues.Add('4', '4');
            intvalues.Add('5', '5');
            intvalues.Add('6', '6');
            intvalues.Add('7', '7');
            intvalues.Add('8', '8');
            intvalues.Add('9', '9');
            intvalues.Add('0', '0');
           // intvalues.Add('.', '.');

            Dictionary<string, string> SIGNOP = new System.Collections.Generic.Dictionary<string, string>();

            SIGNOP.Add("+=", "COMP_ASSGN");
            SIGNOP.Add("-=", "COMP_ASSGN");
            SIGNOP.Add("*=", "COMP_ASSGN");
            SIGNOP.Add("/=", "COMP_ASSGN");
            SIGNOP.Add("%=", "COMP_ASSGN");
            SIGNOP.Add("=", "=");

            Dictionary<string, string> PM = new System.Collections.Generic.Dictionary<string, string>();

            PM.Add("+", "PM");
            PM.Add("-", "PM");

            Dictionary<string, string> RO = new System.Collections.Generic.Dictionary<string, string>();
            RO.Add("<", "ROP");
            RO.Add(">", "ROP");
            RO.Add("<=", "ROP");
            RO.Add(">=", "ROP");
            RO.Add("!=", "ROP");
            RO.Add("==", "ROP");
            RO.Add("!", "!");




            Dictionary<string, string> MDM = new System.Collections.Generic.Dictionary<string, string>();
            MDM.Add("*", "MDM");
            MDM.Add("/", "MDM");
            MDM.Add("%", "MDM");

            Dictionary<string, string> LO = new System.Collections.Generic.Dictionary<string, string>();
            LO.Add("&&", "&&");
            LO.Add("||", "&&");
            Dictionary<string, string> INC = new System.Collections.Generic.Dictionary<string, string>();
            INC.Add("++", "INC_DEC");
            INC.Add("--", "INC_DEC");
            Dictionary<string, string> PUNCTUATORS= new System.Collections.Generic.Dictionary<string, string>();


            PUNCTUATORS.Add("{", "{");
            PUNCTUATORS.Add("}", "}");
            PUNCTUATORS.Add(")", ")");
            PUNCTUATORS.Add("(", "(");
            PUNCTUATORS.Add(";", ";");
            PUNCTUATORS.Add(".", ".");
            PUNCTUATORS.Add("[", "[");
            PUNCTUATORS.Add("]", "]");
            PUNCTUATORS.Add(",", ",");
            PUNCTUATORS.Add(":", ":");

            Dictionary<string, string> PUNCTUATOR = new System.Collections.Generic.Dictionary<string, string>();


            PUNCTUATOR.Add("{", "{");
            PUNCTUATOR.Add("}", "}");
            PUNCTUATOR.Add(")", ")");
            PUNCTUATOR.Add("(", "(");
            PUNCTUATOR.Add(";", ";");
            PUNCTUATOR.Add("[", "[");
            PUNCTUATOR.Add("]", "]");
            PUNCTUATOR.Add(",", ",");
            PUNCTUATOR.Add(":", ":");



            Dictionary<string, string> KEYWORDS = new Dictionary<string, string>();
            KEYWORDS.Add("for", "for");


            Dictionary<string, string> Foreach = new Dictionary<string, string>();
            KEYWORDS.Add("foreach", "foreach");
            Dictionary<string, string> WHILE = new Dictionary<string, string>();
            KEYWORDS.Add("while", "while");
            KEYWORDS.Add("do", "do");


            Dictionary<string, string> Then = new Dictionary<string, string>();
            KEYWORDS.Add("then", "then");

            Dictionary<string, string> If = new Dictionary<string, string>();
            KEYWORDS.Add("if", "if");
            Dictionary<string, string> Else = new Dictionary<string, string>();
            KEYWORDS.Add("else", "else");
            Dictionary<string, string> Elseif = new Dictionary<string, string>();
            KEYWORDS.Add("else_if", "else_if");



            Dictionary<string, string> Switch = new Dictionary<string, string>();
            KEYWORDS.Add("switch", "switch");
            Dictionary<string, string> Case = new Dictionary<string, string>();
            KEYWORDS.Add("case", "case");
            Dictionary<string, string> List = new Dictionary<string, string>();
            KEYWORDS.Add("List", "List");
            Dictionary<string, string> Class = new Dictionary<string, string>();
            KEYWORDS.Add("class", "class");
            KEYWORDS.Add("Main", "Main");
            KEYWORDS.Add("Public", "ACC_MOD");
            KEYWORDS.Add("Private", "ACC_MOD");
            KEYWORDS.Add("void", "void");


            Dictionary<string, string> Abstract = new Dictionary<string, string>();
            KEYWORDS.Add("abs", "ABSTRACT");
            Dictionary<string, string> Inheritance = new Dictionary<string, string>();
            KEYWORDS.Add("extend", "INHERITANCE");

            Dictionary<string, string> Interface = new Dictionary<string, string>();
            KEYWORDS.Add("iextend", "INTERFACE");

            Dictionary<string, string> Override = new Dictionary<string, string>();
            KEYWORDS.Add("override", "override");
            Dictionary<string, string> Try = new Dictionary<string, string>();
            KEYWORDS.Add("try", "try");
            Dictionary<string, string> Catch = new Dictionary<string, string>();
            KEYWORDS.Add("catch", "catch");
            KEYWORDS.Add("finally", "finally");
            KEYWORDS.Add("default", "default");
            KEYWORDS.Add("break", "break");
            KEYWORDS.Add("return", "return");





            Dictionary<string, string> New = new Dictionary<string, string>();
            KEYWORDS.Add("new", "new");
          //  Dictionary<string, string> KEWORDS = new Dictionary<string, string>();
            KEYWORDS.Add("int", "DT");
            KEYWORDS.Add("float", "DT");
            KEYWORDS.Add("char", "DT");
            KEYWORDS.Add("string", "DT");
            KEYWORDS.Add("boolean", "DT");

            Dictionary<char, char> DOT = new Dictionary<char, char>();
            DOT.Add('.', '.');
            Dictionary<string, string> BOOLEANCONST = new Dictionary<string, string>();
            KEYWORDS.Add("true", "BOOLEAN_CONST");
            KEYWORDS.Add("false", "BOOLEAN_CONST");





            var temp = "";
            char c = ' ';
            //string enter = "\r\n";



            var file = new StreamWriter("C:\\Users\\ADMIN\\Desktop\\tokenset.txt");  // File.Create("C:\\Users\\ADMIN\\Desktop\\tokenset.txt");

           
           

            string s = File.ReadAllText("1.txt");

            int e = 0;
            int line = 1;

            int i = 0;
            for (; i < s.Length; i++)
            {
                temp = "";
                
                if (s[i] == '\r' || e==1)
                {
                   
                    e = 0;
                    temp = "";
                    ++line;

                    i = i + 2;

                }


                int allow = 0;

                int dotCounter = 0;


                ///////String/////////////

                if (s.Length<= i)
                {
                   
                    
                    break;
                }
                if(s[i]==' ')
                {
                   
                  
                    
                     temp = "";
                    ++i;
                    if (s.Length <= i)
                    {
                        
                        break;
                    }

                }
                if (s[i] == '"')
                {
                    i++;             
                    while (s[i] != '"')
                    {
                       
                        
                        if (s[i] == '\\')
                        { 
                            
                            ++i;
                            if (s.Length <= i)
                            {
                                allow = 1;
                                temp = temp + s[--i];
                               // Console.WriteLine("({0},{1},{2})", "Laxical Error", "_", line);
                                break;
                            }
                            else

                            if (s[i] == '\r')
                            {
                               
                                temp = temp + s[--i];
                                allow = 1;
                                
                                //   Console.WriteLine("({0},{1},{2})", "Laxical Error", "_", line);
                                e = 1;
                                
                                break;
                            }
                            else
                            if (s[i]==' ')
                            {
                                temp = temp + s[--i];
                               
                                allow = 1;
                                break;
                            }
                            else
                            {

                                temp = temp + s[i];

                            }
                          
                            


                        }
                        else
                        {

                            if (s[i] == '\r')
                            {

                                allow = 1;
                                
                                e = 1;
                                // Console.WriteLine("({0},{1},{2})", "Laxical Error", "_", line);
                                --i;
                                break;
                            }

                            temp = temp + s[i];
                           
                        }

                       
                     
                        i++;
                        if (s.Length ==i)
                        {
                            allow = 1;
                            break;
                        }
                    }
                    
                    
                    if (allow==0)
                    {
                        
                        Console.WriteLine("{0} {1} {2}", "STRING_CONST", temp, line);
                        file.WriteLine("{0} {1} {2}", "STRING_CONST", temp, line);
                       

                    }
                  if(allow==1)
                    {
                        Console.WriteLine("{0} {1} {2}", "Invalid", temp, line);
                        file.WriteLine("{0} {1} {2}", "Invalid", temp, line);

                    }
                }

                else
                ///////////////////CHAR///////////////////

                //start character
                if (s[i] == '\'')
                {
                    
                    int n = 1;
                    i++;
                    //file length checking
                    if (s.Length <= i)
                    {
                        //Console.WriteLine("({0},{1},{2})", "Laxical Error", "_", line);
                        allow = 1;
                        //Console.WriteLine("Ending File");
                        break;
                    }

                    //('')char error checking
                    if (s[i] == '\'')
                    {
                        temp = temp + s[i];
                        allow = 1;

                        //Console.WriteLine("({0},{1},{2})", "Laxical Error", "_", line);

                    }
                    //character ending checking
                    while (s[i] != '\'')
                    {

                        n++;
                       
                        if (n == 4 || n == 3)
                        {
                            allow = 1;

                           // Console.WriteLine("({0},{1},{2})", "Laxical Error", "_", line);

                            break;
                        }
                        // (with \)char checking
                        if (s[i] == '\\')
                        {
                           i++;
                            n++;
                            if (s[i] == ' ')
                            {
                                //Console.WriteLine("Error of space after \\ ");
                                //Console.WriteLine("({0},{1},{2})", "Laxical Error", "_", line);
                                temp = temp + s[i];
                                break;
                            }
                            else
                               // (with \ enter)char error checking

                               if (s[i] == '\r')
                            {
                                allow = 1;

                              
                                // Console.WriteLine("error of enter after \\ ");
                               // Console.WriteLine("({0},{1},{2})", "Laxical Error", "_", line);
                                e = 1;
                                --i;
                                break;

                            }
                            else
                            {
                                
                                temp = temp+s[i];
                            }

                        }
                        else

                         if (s[i] == '\r')
                        {
                            allow = 1;
                           
                            // Console.WriteLine("Enter Error without \\");
                          //  Console.WriteLine("({0},{1},{2})", "Laxical Error", "_", line);
                            e = 1;
                            --i;
                            break;

                        }
                        else
                        {
                            temp = temp + s[i];
                        }
                        i++;
                         //length error
                        if (s.Length == i)
                        {
                            allow = 1;
                           // Console.WriteLine("({0},{1},{2})", "Laxical Error", "_", line);

                           // Console.WriteLine("Ending File");
                            break;
                        }
                        }
                    if (allow == 0) {
                        
                        Console.WriteLine("{0} {1} {2}", "Char", temp, line);
                        file.WriteLine("{0} {1} {2}", "CHAR_CONST", temp, line);
                    }
                    else if(allow==1)
                    {
                        Console.WriteLine("{0} {1} {2}", "Invalid", temp, line);
                        file.WriteLine("{0} {1} {2}", "Invalid", temp, line);
                        

                    }
                }

                else
                    /////////////////INTEGER///////////
  
                if (s[i] == '-' || s[i] == '+' || intvalues.ContainsKey(s[i])  || DOT.ContainsKey(s[i]))
                {

                   

                    if (s[i] == '-' || s[i] == '+')

                    {
                        if (!intvalues.ContainsKey(s[++i]))
                        {
                            
                            --i;

                            temp = temp + s[i];
                            ++i;
                            if (s.Length == i)
                            {
                                Console.WriteLine("{0} {1} {2}", PM[temp], temp, line);
                                file.WriteLine("{0} {1} {2}", PM[temp], temp, line);


                                break;
                            }
                       
                            if (PM.ContainsKey(s[i].ToString())  && s[i].ToString()==temp)
                            {
                              

                                temp = temp + s[i];
                                
                                Console.WriteLine("{0} {1} {2}", INC[temp], temp, line);
                                file.WriteLine("{0} {1} {2}", INC[temp], temp, line);


                            }
                            else if (SIGNOP.ContainsKey(s[i].ToString()))
                            {
                                temp = temp + s[i];
                                Console.WriteLine("{0} {1} {2}", SIGNOP[temp], temp, line);
                                file.WriteLine("{0} {1} {2}", SIGNOP[temp], temp, line);

                                //++i;
                            }
                            else
                            {
                                Console.WriteLine("{0} {1} {2}", PM[temp], temp, line);
                                file.WriteLine("{0} {1} {2}", PM[temp], temp, line);


                                --i;
                            }
                            if (s[i] == '\r')
                            {
                                e = 1;
                                break;
                            }


                        }
                        else
                        {

                            c = s[--i];

                        }


                    }
                    if (s.Length <=i)
                    {
                        if ((intvalues.ContainsKey(s[++i]) ))
                        {


                            Console.WriteLine("{0} {1} {2}", s[i], s[i], line);
                            file.WriteLine("{0} {1} {2}", s[i], s[i], line);


                            break;
                        }
                        --i;
                    }
                  
                  
                    if (intvalues.ContainsKey(s[i]) ||  DOT.ContainsKey(s[i]) )
                    {
                        
                       
                      
                        temp = temp + c;
                       
                        while (!(s[i] == ' ' || SIGNOP.ContainsKey(s[i].ToString())|| PM.ContainsKey(s[i].ToString()) || MDM.ContainsKey(s[i].ToString()) || RO.ContainsKey(s[i].ToString()) || PUNCTUATOR.ContainsKey(s[i].ToString()) || s[i] == '\r'))
                        {
                            
                            
                            if (!(intvalues.ContainsKey(s[i]) || DOT.ContainsKey(s[i])))
                            {

                              
                                while (!(s[i] == ' ' || SIGNOP.ContainsKey(s[i].ToString())|| PUNCTUATORS.ContainsKey(s[i].ToString()) || PM.ContainsKey(s[i].ToString()) || MDM.ContainsKey(s[i].ToString())|| RO.ContainsKey(s[i].ToString())|| s[i]=='\r'))
                                {
                                    temp = temp + s[i];
                                    i++;
                                    if (s.Length==i)
                                    {
                                        break;
                                    }
                                    if (s[i] == '\r')
                                    {
                                        e = 1;
                                    }


                                }
                              
                                allow = 1;
                              //  Console.WriteLine("({0},{1},{2})", "Laxical Errors", "_", line);
                                
                                
                                break;
                            }
                            else
                            {

                               
                                //Console.WriteLine(s[i]);
                                
                                temp = temp + s[i];
                               
                                if (s[i] == '.')
                                {
                                   
                                    dotCounter++;
                                    ++i;

                                   

                                    if (dotCounter >= 2)
                                    {
                                       // Console.WriteLine("({0},{1},{2})", "Laxical Error", "_", line);
                                        allow = 1;
                                        //Console.WriteLine("float cannot conatin more than one dot");
                                       
                                    }
                                    if (s.Length == i)
                                    {
                                       
                                       // Console.WriteLine("({0},{1},{2})", "Laxical Error", "_", line);
                                        allow = 1;
                                        break;
                                    }
                                    if (s[i] == ' ')
                                    {
                                      
                                     //   Console.WriteLine("({0},{1},{2})", "Laxical Error", "_", line);
                                        allow = 1;
                                        // Console.WriteLine("Error");
                                        break;
                                    }
                                    --i;

                                }
                              
                                i++;
                                if (s.Length == i)
                                {

                                    break;
                                }

                            }
                          
                        }
                        --i;

                        if (allow == 0)
                        {
                            if (temp.Contains('.')) {

                                Console.WriteLine("{0} {1} {2}", "FLOAT_CONST", temp, line);
                                file.WriteLine("{0} {1} {2}", "FLOAT_CONST", temp, line);


                            }
                            else
                            {
                                
                                Console.WriteLine("{0} {1} {2}", "INT_CONST", temp, line);
                                file.WriteLine("{0} {1} {2}", "INT_CONST", temp, line);


                            }
                        }

                        if (allow==1)
                        {
                            Console.WriteLine("{0} {1} {2}", "Invalids",temp, line);
                            file.WriteLine("{0} {1} {2}", "Invalid", temp, line);

                        }
                    }
                }

                else
                //////IDENTIFIER/////


                if (s[i]=='_')
                {
                   
                    i++;

                    if (s.Length==i || s[i]==' ')
                    {
                        temp = temp + s[--i];
                      //  Console.WriteLine("({0},{1},{2})", "Laxical Errors", "_", line);
                        allow = 1;
                     
                       
                    }
                    else
                    if (intvalues.ContainsKey(s[i]))
                    {
                        temp = temp + s[--i];
                        ++i;
                        while (!(s[i] == ' ' || SIGNOP.ContainsKey(s[i].ToString())))
                        {
                           
                            temp = temp + s[i];
                            i++;
                            if (s.Length==i)
                            {
                             

                                break;

                            }
                        }

                        //    Console.WriteLine("({0},{1},{2})", "Laxical Error"+temp, "_", line);
                        allow = 1;
                        // Console.WriteLine("Error");


                    }
                    else
                    {
                        --i;
                       //
                        //while (!(s[i] == ' ' || SIGNOP.ContainsKey(s[i].ToString()) || PM.ContainsKey(s[i].ToString()) || MDM.ContainsKey(s[i].ToString()) || RO.ContainsKey(s[i].ToString()) || s[i]=='\r' ))
                       while((s[i]>='A' && s[i]<='Z')|| (intvalues.ContainsKey(s[i]))|| (s[i] >= 'a' && s[i] <= 'z')||(s[i]=='_'))
                        {
                           
                            temp = temp + s[i];
                            i++;
                            if (s.Length == i)
                            {
                              
                                break;

                            }
                            if (s[i]=='\r')
                            {
                                e = 1;
                            }

                        }

                        --i;

                        if (allow==0)
                        {
                            Console.WriteLine("{0} {1} {2}", "ID", temp,line);
                            file.WriteLine("{0} {1} {2}", "ID", temp, line);

                        }




                    }
                    if (allow == 1)
                    {
                        Console.WriteLine("{0} {1} {2}", "invalid", temp, line);
                        file.WriteLine("{0} {1} {2}", "Invalid", temp, line);


                    }
                }
                //assign operater
                else if (SIGNOP.ContainsKey(s[i].ToString()))
                {
                   
                    temp = temp + s[i];
                    
                    ++i;
                    if (s.Length==i)
                    {    Console.WriteLine("{0} {1} {2}", SIGNOP[temp], temp, line);
                        file.WriteLine("{0} {1} {2}", SIGNOP[temp], temp, line);



                        break;
                    }
                    if (s[i]=='\r')
                    {
                        
                        e = 1;
                        
                      
                    }

                    if (SIGNOP.ContainsKey(s[i].ToString()))
                    {
                        temp = temp + s[i];
                        Console.WriteLine("{0} {1} {2}", RO[temp], temp, line);
                        file.WriteLine("{0} {1} {2}", RO[temp], temp, line);



                    }
                    else
                    {
                        Console.WriteLine("{0} {1} {2}", SIGNOP[temp], temp, line);
                        file.WriteLine("{0} {1} {2}", SIGNOP[temp], temp, line);

                        --i;
                    }




                }

                //Plus Minus OR With Asign Operater
                else if (PM.ContainsKey(s[i].ToString()))
                {
                    temp = temp + s[i];
                    ++i;
                    if (s.Length == i)
                    {
                        Console.WriteLine("{0} {1} {2}", PM[temp], temp, line);
                        file.WriteLine("{0} {1} {2}", PM[temp], temp, line);


                        break;
                    }
                    
                    if (PM.ContainsKey(s[i].ToString()))
                    {
                        temp = temp + s[i];

                        Console.WriteLine("{0} {1} {2}", INC[temp], temp, line);
                        file.WriteLine("{0} {1} {2}", INC[temp], temp, line);

                    }
                    else if (SIGNOP.ContainsKey(s[i].ToString()))
                    {
                        temp = temp + s[i];
                        Console.WriteLine("{0} {1} {2}", SIGNOP[temp], temp, line);
                        file.WriteLine("{0} {1} {2}", SIGNOP[temp], temp, line);

                    }
                    else
                    {
                        Console.WriteLine("{0} {1} {2}", PM[temp], temp, line);
                        file.WriteLine("{0} {1} {2}", PM[temp], temp, line);

                        --i;

                    }

                    if (s[i] == '\r')
                    {
                        e = 1;

                    }



                }
                //MDM With or without asign operator
                else if (MDM.ContainsKey(s[i].ToString()))
                {
                   
                    temp = temp + s[i];
                    ++i;

                    if (s.Length == i)
                    {
                        Console.WriteLine("{0} {1} {2}", MDM[temp], temp, line);
                        file.WriteLine("{0} {1} {2}", MDM[temp], temp, line);


                        break;
                    }
                    


                    if (SIGNOP.ContainsKey(s[i].ToString()))
                    {
                        temp = temp + s[i];
                        Console.WriteLine("{0} {1} {2}", SIGNOP[temp], temp, line);
                        file.WriteLine("{0} {1} {2}", SIGNOP[temp], temp, line);



                    }
                    else
                    {
                        Console.WriteLine("{0} {1} {2}", MDM[temp], temp, line);
                        file.WriteLine("{0} {1} {2}", MDM[temp], temp, line);

                        --i;
                    }
                    if (s[i] == '\r')
                    {
                        e = 1;
                        
                    }



                }

                ///RO 
                else if (RO .ContainsKey(s[i].ToString()))
                {
                   
                    temp = temp + s[i];
                   
                    ++i;

                    if (s.Length == i)
                    {
                        Console.WriteLine("{0} {1} {2}", RO[temp], temp, line);
                        file.WriteLine("{0} {1} {2}", RO[temp], temp, line);


                        break;
                    }



                    if (SIGNOP.ContainsKey(s[i].ToString()))
                    {
                        temp = temp + s[i];
                        Console.WriteLine("{0} {1} {2}", RO[temp], temp, line);
                        file.WriteLine("{0} {1} {2}", RO[temp], temp, line);



                    }
                    else
                    {
                        Console.WriteLine("{0} {1} {2}", RO[temp], temp, line);
                        file.WriteLine("{0} {1} {2}", RO[temp], temp, line);

                        --i;
                    }
                    if (s[i] == '\r')
                    {
                        
                        e = 1;
                       
                        
                    }


                }


                ///Punctuators
                else if (PUNCTUATORS.ContainsKey(s[i].ToString()))
                {

                    temp = temp + s[i];
                    Console.WriteLine("{0} {1} {2}", temp, temp, line);
                    file.WriteLine("{0} {1} {2}", temp, temp, line);


                   
                }


                else
                {
                   
                   

                    
                    while (!(s[i]==' '|| PUNCTUATORS.ContainsKey(s[i].ToString())||s[i]=='\r'||s[i]=='"'||s[i]=='\''|| SIGNOP.ContainsKey(s[i].ToString())|| RO.ContainsKey(s[i].ToString())|| PM.ContainsKey(s[i].ToString()) 
                        || intvalues.ContainsKey(s[i]) || KEYWORDS.ContainsKey(temp)
                        || INC.ContainsKey(temp) || LO.ContainsKey(temp) || s[i]=='_' || MDM.ContainsKey(s[i].ToString())))
                    {


                        if (s[i] != ' ')
                        {
                           // Console.WriteLine(s[i]);
                            temp = temp + s[i];
                            temp = Regex.Replace(temp, @"\s", "");
                            //temp= temp.Replace(" ", string.Empty);

                        }
                      //  Console.WriteLine(temp);
                        ++i;
                        
                       
                        
                        if (s.Length == i)
                        {
                            break;
                        }
                        //if (PUNCTUATORS.ContainsKey(s[i].ToString()))
                        //{
                        //    --i;
                        //    break;
                        //}
                       
                        if (s[i] == '\r')
                        {
                           
                            
                            e = 1;
                            
                            break;
                        }



                    }
                    --i;




                    if (KEYWORDS.ContainsKey(temp))
                    {
                       
                        Console.WriteLine("{0} {1} {2}", KEYWORDS[temp], temp, line);
                        file.WriteLine("{0} {1} {2}", KEYWORDS[temp], temp, line);


                    }
                    
                    else
                    {
                        if (!(s[i]!=' ' || s[i] != '\r'))
                        {

                            Console.WriteLine("{0} {1} {2}", "Invalid", temp, line);
                            file.WriteLine("{0} {1} {2}", "Invalid", temp, line);

                        }






                    }






                }





























            }

            file.Dispose();


            

        }
    }
}
