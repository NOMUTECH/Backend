#include <iostream>

using namespace std;

int main()
{
	// 3. index sutun: toplam puan -- 4. index sutun: toplam madalya sayisi
	int madalya_tablo[6][5];
	int enb_p = 0; int enb_m = 0;
	int yil=2018;
	for (int p = 0; p < 6; p++) {
		int madalya_sayisi = 0;
		for (int k = 0; k < 5; k++) {
			if (k == 0) {
				cout <<yil<<" yilinda altin madalya sayisi? ";
				cin >> madalya_tablo[p][k];
				madalya_sayisi += madalya_tablo[p][k];
			}
			else if (k == 1) {
				cout << yil << " yilinda gumus madalya sayisi? ";
				cin >> madalya_tablo[p][k];
				madalya_sayisi += madalya_tablo[p][k];
			}
			else if (k == 2) {
				cout << yil << " yilinda bronz madalya sayisi? ";
				cin >> madalya_tablo[p][k];
				madalya_sayisi += madalya_tablo[p][k];
			}
			else if (k == 3) {
				madalya_tablo[p][k] = (madalya_tablo[p][0] * 5) + (madalya_tablo[p][1] * 3) + (madalya_tablo[p][2] * 1);
			}
			else if (k == 4) {
				madalya_tablo[p][k] = madalya_sayisi;
			}
		}
		yil += 1;
	}
	for (int h = 0; h < 6; h++) {
		if (madalya_tablo[h][3] > enb_p) {
			enb_p = madalya_tablo[h][3];
		}
		if (madalya_tablo[h][4] > enb_m) {
			enb_m = madalya_tablo[h][4];
		}
	}
	cout << "En fazla madalya sayisi:" << enb_m;
	cout << "En fazla puan sayisi:" << enb_p;
}