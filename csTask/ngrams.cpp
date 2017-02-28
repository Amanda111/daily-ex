#include <cctype>
#include <cmath>
#include <fstream>
#include <iostream>
#include <string>
#include "simpio.h"
#include "vector.h"
#include "map.h"
#include "console.h"
#include "random.h"

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

void AddToDict(Map<Vector<string>,Vector<string>> &dict,string text,Vector<string> key,Vector<Vector<string>> &keys){
    Vector<string> values;
    values.add(text);
    if(dict.containsKey(key)){
        values = dict.get(key);
        values.add(text);
        dict.put(key,values);
    }else{
        dict.put(key,values);
        cout<<key<<endl;
        keys.add(key);
    }
}

void ReadTextFile(ifstream & infile, Map<Vector<string>,Vector<string>> &dict,Vector<Vector<string>> &keys,int num) {
   int a = 1;
   string text;
   Vector<string> key;
   Vector<string> fronts;
   while (true) {
      infile >> text;
      if (infile.fail()) break;
      if(a<num){
          key.add(text);
          fronts.add(text);
      }else{
          AddToDict(dict,text,key,keys);
          key.remove(0);
          key.add(text);
      }
      a++;
    }
   //
   for(int i = 0;i<num-1;i++){
       AddToDict(dict,fronts[i],key,keys);
       key.remove(0);
       key.add(fronts[i]);
   }
}

void Generator(Vector<string> &start,Map<Vector<string>,Vector<string>> dict,Vector<string> &para,int words){
    Vector<string> suffix;
    suffix = dict.get(start);
    int rvalue = randomInteger(0, suffix.size()-1);
    cout<<suffix[rvalue]<<endl;
    para.add(suffix[rvalue]);
    start.remove(0);
    start.add(suffix[rvalue]);
    if(para.size()>words) return;
    Generator(start,dict,para,words);
}

int main() {
    // TODO: Finish the program!
    ifstream infile;
    AskUserForInputFile("Input file: ", infile);
    Map<Vector<string>,Vector<string>> dict;
    Vector<Vector<string>> keys;
    Vector<string> para;
    int num,words;
    cout<< "Value of N?";
    cin >> num;
    ReadTextFile(infile, dict,keys,num);
    infile.close();
    cout<<"# of random words to generate (0 to quit)?";
    cin >> words;
    int rkey = randomInteger(0, keys.size()-1);
    cout<<keys[rkey]<<endl;
    para = keys[rkey];
    Generator(keys[rkey],dict,para,words);
    cout << "Exiting." << endl;
    return 0;
}
