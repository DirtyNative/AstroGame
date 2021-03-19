import 'package:astrogame_app/models/stellar/systems/solar_system.dart';
import 'package:astrogame_app/repositories/solar_system_repository.dart';
import 'package:astrogame_app/services/event_service.dart';
import 'package:astrogame_app/views/solar_system/events/solar_system_loaded_event.dart';
import 'package:flutter/cupertino.dart';
import 'package:injectable/injectable.dart';
import 'package:stacked/stacked.dart';

@injectable
class StartViewModel extends BaseViewModel {
  SolarSystemRepository _solarSystemRepository;
  EventService _eventService;

  TextEditingController solarSystemNumberController;

  StartViewModel(this._solarSystemRepository, this._eventService) {
    solarSystemNumberController = new TextEditingController();
  }

  Future loadSolarSystemAsync() async {
    var solarSystem = await runBusyFuture(_fetchSolarSystem());

    _eventService.fire(new SolarSystemLoadedEvent(solarSystem));
  }

  Future<SolarSystem> _fetchSolarSystem() {
    return _solarSystemRepository.getBySystemNumberRecursiveAsync(
        int.parse(solarSystemNumberController.text));
  }
}
