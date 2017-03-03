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

void AddToDict(Map<Vector<string>,Vector<string>> &dict,string text,Vector<string> key){
    Vector<string> values;
    values.add(text);
    if(dict.containsKey(key)){
        values = dict.get(key);
        values.add(text);
        dict.put(key,values);
    }else{
        dict.put(key,values);
        cout<<key<<endl;
    }
}

void ReadTextFile(ifstream & infile, Map<Vector<string>,Vector<string>> &dict,int num) {
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
          AddToDict(dict,text,key);
          key.remove(0);
          key.add(text);
      }
      a++;
    }
   for(int i = 0;i<num-1;i++){
       AddToDict(dict,fronts[i],key);
       key.remove(0);
       key.add(fronts[i]);
   }
}

void Generator(Vector<string> &start,Map<Vector<string>,Vector<string>> dict,int a,int words){
    if(a>=words) return;
    Vector<string> suffix;
    suffix = dict.get(start);
    int rvalue = randomInteger(0, suffix.size()-1);
    cout<<suffix[rvalue]<<" ";
    start.remove(0);
    start.add(suffix[rvalue]);
    a+=1;
    Generator(start,dict,a,words);
}

int main() {
    ifstream infile;
    AskUserForInputFile("Input file: ", infile);
    Map<Vector<string>,Vector<string>> dict;
    int num,words;
    cout<< "Value of N?";
    cin >> num;
    ReadTextFile(infile, dict,num);
    infile.close();
    cout<<"# of random words to generate (0 to quit)?";
    cin >> words;
    Vector<Vector<string>> keys;
    Vector<string> start;
    keys = dict.keys();
    int rkey = randomInteger(0, keys.size()-1);
    start = keys[rkey];
    int a = start.size();
    for(int i = 0;i<a;i++){
        cout<<start[i]<<" ";
    }
    Generator(start,dict,a,words);
    return 0;
}
