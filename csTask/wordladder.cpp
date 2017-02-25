// This is the CPP file you will edit and turn in.
// Also remove these comments here and add your own.
// TODO: remove this comment header

#include <cctype>
#include <cmath>
#include "simpio.h"
#include "vector.h"
#include <string>
#include <stack>
#include "stack.h"
#include "queue.h"
#include "map.h"
#include <fstream>
#include <iostream>
#include "console.h"


using namespace std;

void AskUserForInputFile(string prompt, ifstream & infile) {
   while (true) {
      cout << prompt;
      string filename = getLine();
      infile.open(filename.c_str());
      if (!infile.fail()) break;
      cout << "Unable to open " << filename << endl;
      infile.clear();
    }
}


void ReadTextFile(ifstream & infile, Vector<string> & lines) {
   while (true) {
      string line;
      getLine(infile, line);
      if (infile.fail()) break;
      lines.add(line);
    }
}

void PrintReversed(Vector<string> & lines) {
   for (int i = lines.size() - 1; i >= 0; i--) {
      cout << lines[i] << endl;
   }
}

bool LocateWord(Vector<string> & lines,string word){
    for (int i = 0; i <= lines.size() - 1; i++) {
       if(lines[i] == word){
           return true;
       }
    }
    return false;
}


bool Ladder(string input,string output,Stack<string> &stringStack,Vector<string> & lines){
    Queue<Stack<string>> stackqueue;
    Stack<string> newStack;
    Map<string,string> hadfound;
    newStack.push(input);
    stackqueue.enqueue(newStack);
    while(!stackqueue.isEmpty()){
        newStack = stackqueue.dequeue();
        string neighbour = newStack.peek();
        for(int i = 0;i<neighbour.length();i++){
            string charinput = neighbour;
            for(int j = 97;j<=122;j++){
                charinput[i]= char(j);
                if(charinput != neighbour && LocateWord(lines,charinput)){
                    if(!hadfound.containsKey(charinput)){
                        if(charinput == output){
                            newStack.push(charinput);
                            stringStack = newStack;
                            return true;
                        }else{
                            Stack<string> copyStack;
                            copyStack = newStack;
                            copyStack.push(charinput);
                            stackqueue.enqueue(copyStack);
                        }
                    }
                }
            }
        }

    }
    return false;
}




int main() {
    // TODO: Finish the program!
    ifstream infile;
    AskUserForInputFile("Input file: ", infile);
    Vector<string> lines;
    ReadTextFile(infile, lines);
    infile.close();
    string inputWord,outputWord;
    cout<<"Word #1 (or Enter to quit): ";
    cin>>inputWord;
    cout<<"Word #2 (or Enter to quit): ";
    cin>>outputWord;
    Stack<string> stringStack;
    Map<string,string> hadfound;
    if(inputWord != outputWord){
        if(inputWord.length() == outputWord.length()){
            if(LocateWord(lines,inputWord) && LocateWord(lines,outputWord)){
                if(Ladder(inputWord,outputWord,stringStack,lines)){
                    while(stringStack.size()){
                        string hah = stringStack.pop();
                        cout<<hah<<endl;
                    }
                };
            }
        }else{
            cout<<"are not the same length"<<endl;
        }
    }else{
        cout<<"they are the same word"<<endl;
    }
//    PrintReversed(lines);
    cout << "Have a nice day." << endl;
    return 0;
}
