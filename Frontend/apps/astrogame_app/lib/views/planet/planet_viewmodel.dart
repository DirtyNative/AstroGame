import 'package:astrogame_app/models/stellar/stellar_objects/planet.dart';
import 'package:astrogame_app/services/navigation_wrapper.dart';
import 'package:stacked/stacked.dart';

class PlanetViewModel extends BaseViewModel {
  NavigationWrapper _navigationService;

  Planet _planet;
  Planet get planet => _planet;
  set planet(Planet val) {
    _planet = val;
    notifyListeners();
  }

  String get imageUrl =>
      'https://localhost:7555/api/v1/image/stellar-object/${planet.id}';

  PlanetViewModel(this._navigationService, this._planet);

  void goBack() {
    _navigationService.back();
  }
}
