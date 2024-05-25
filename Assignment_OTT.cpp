#include "iostream"

using namespace std;

class X {
private:
	int x;

public:

	X(int _x): x(_x){}
};

void main() {
	X* Test;
	Test = new X[2]{(2),(3)};
	cout << "wow";
}

