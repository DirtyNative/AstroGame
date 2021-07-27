import 'package:astrogame_app/bags/show_planet_view_bag.dart';
import 'package:astrogame_app/helpers/route_paths.dart';
import 'package:astrogame_app/models/stellar/stellar_objects/planet.dart';
import 'package:astrogame_app/models/stellar/systems/solar_system.dart';
import 'package:astrogame_app/services/event_service.dart';
import 'package:astrogame_app/services/navigation_wrapper.dart';
import 'package:astrogame_app/views/solar_system/events/solar_system_loaded_event.dart';
import 'package:injectable/injectable.dart';
import 'package:stacked/stacked.dart';

@injectable
class SolarSystemViewModel extends BaseViewModel {
  EventService _eventService;
  NavigationWrapper _navigationService;

  SolarSystemViewModel(
    this._eventService,
    this._navigationService,
  ) {
    _eventService.on<SolarSystemLoadedEvent>().listen((event) {
      solarSystem = null;
      solarSystem = event.solarSystem;
    });
  }

  SolarSystem? _solarSystem;
  SolarSystem? get solarSystem => _solarSystem;
  set solarSystem(SolarSystem? val) {
    _solarSystem = val;
    notifyListeners();
  }

  Future showPlanetView(Planet planet) async {
    var viewBag = new ShowPlanetViewBag(planet);
    await _navigationService.navigateTo(RoutePaths.PlanetViewRoute,
        arguments: viewBag);
  }
}
