import 'package:astrogame_app/models/stellar/stellar_objects/moon.dart';
import 'package:stacked/stacked.dart';

class MoonCardViewModel extends BaseViewModel {
  Moon _moon;
  Moon get moon => _moon;
  set moon(Moon val) {
    _moon = val;
    notifyListeners();
  }

  MoonCardViewModel(this._moon);
}
