import 'package:astrogame_app/models/stellar/stellar_objects/planet.dart';
import 'package:stacked/stacked.dart';
import 'package:stacked_services/stacked_services.dart';

class PlanetViewModel extends BaseViewModel {
  NavigationService _navigationService;

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
