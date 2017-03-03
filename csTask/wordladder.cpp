#include <cctype>
#include <cmath>
#include "simpio.h"
#include <string>
#include <stack>
#include "stack.h"
#include "queue.h"
#include "lexicon.h"
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

bool Ladder(string input,string output,Stack<string> &stringStack,Lexicon & lines){
    Queue<Stack<string>> stackqueue;
    Stack<string> newStack;
    Lexicon hadfound;
    newStack.push(input);
    stackqueue.enqueue(newStack);
    while(!stackqueue.isEmpty()){
        newStack = stackqueue.dequeue();
        string neighbour = newStack.peek();
        for(int i = 0;i<neighbour.length();i++){
            string charinput = neighbour;
            for(int j = 97;j<=122;j++){
                charinput[i]= char(j);
                if(charinput != neighbour && lines.contains(charinput)){
                    if(!hadfound.contains(charinput)){
                        if(charinput == output){
                            newStack.push(charinput);
                            stringStack = newStack;
                            return true;
                        }else{
                            Stack<string> copyStack;
                            copyStack = newStack;
                            copyStack.push(charinput);
                            stackqueue.enqueue(copyStack);
                            hadfound.add(charinput);
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
    Lexicon lines(infile);
    infile.close();
    string inputWord,outputWord;
    cout<<"Word #1 (or Enter to quit): ";
    cin>>inputWord;
    cout<<"Word #2 (or Enter to quit): ";
    cin>>outputWord;
    inputWord = toLowerCase(inputWord);
    outputWord = toLowerCase(outputWord);
    Stack<string> stringStack;
    if(inputWord != outputWord){
        if(inputWord.length() == outputWord.length()){
            if(lines.contains(inputWord) && lines.contains(outputWord)){
                if(Ladder(inputWord,outputWord,stringStack,lines)){
                    while(stringStack.size()){
                        string hah = stringStack.pop();
                        cout<<hah<<endl;
                    }
                }else{
                    cout<<"Ladder is not found"<<endl;
                }
            }else{
                cout<<"make sure the words are both in the dict"<<endl;
            }
        }else{
            cout<<"are not the same length"<<endl;
        }
    }else{
        cout<<"they are the same word"<<endl;
    }
    cout << "Have a nice day." << endl;
    return 0;
}
