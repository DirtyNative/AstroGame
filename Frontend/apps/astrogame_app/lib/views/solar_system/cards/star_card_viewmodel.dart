import 'package:astrogame_app/models/stellar/stellar_objects/star.dart';
import 'package:stacked/stacked.dart';

class StarCardViewModel extends BaseViewModel {
  Star _star;
  Star get star => _star;
  set star(Star val) {
    _star = val;
    notifyListeners();
  }

  StarCardViewModel(this._star);
}
