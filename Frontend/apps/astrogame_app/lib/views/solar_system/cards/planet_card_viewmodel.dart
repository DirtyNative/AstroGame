import 'package:astrogame_app/bags/show_planet_view_bag.dart';
import 'package:astrogame_app/models/stellar/stellar_objects/planet.dart';
import 'package:stacked/stacked.dart';

class PlanetCardViewModel extends BaseViewModel {
  Planet _planet;
  Planet get planet => _planet;
  set planet(Planet val) {
    _planet = val;
    notifyListeners();
  }

  PlanetCardViewModel(this._planet);
}
