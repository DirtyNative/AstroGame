import 'package:astrogame_app/models/stellar/base_types/stellar_system.dart';
import 'package:astrogame_app/models/stellar/systems/multi_object_system.dart';
import 'package:astrogame_app/models/stellar/systems/single_object_system.dart';
import 'package:astrogame_app/models/stellar/systems/solar_system.dart';
import 'package:astrogame_app/repositories/solar_system_repository.dart';
import 'package:flutter/material.dart';
import 'package:injectable/injectable.dart';
import 'package:stacked/stacked.dart';

@injectable
class StartViewModel extends BaseViewModel {
  SolarSystemRepository _solarSystemRepository;

  SolarSystem _solarSystem;
  SolarSystem get solarSystem => _solarSystem;
  set solarSystem(SolarSystem val) {
    _solarSystem = val;
    notifyListeners();
  }

  StartViewModel(this._solarSystemRepository);

  Future loadSolarSystemAsync() async {
    solarSystem =
        await _solarSystemRepository.getBySystemNumberRecursiveAsync(12);

    print(solarSystem);
  }

  Widget generateSolarSystemWidget(SolarSystem solarSystem) {
    if (solarSystem == null) {
      return SizedBox.shrink();
    }

    return Container(
      child: _generateStarsRow(solarSystem.centerSystems),
    );
  }

  Widget _generateStarsRow(List<StellarSystem> systems) {
    List<Widget> widgets = List.generate(
        systems.length, (index) => _generateSystemWidget(systems[index]));

    return Column(
      children: widgets,
    );
  }

  Widget _generateSystemWidget(StellarSystem system) {
    if (system is SingleObjectSystem) {
      return _generateSingleObjectSystemWidget(system);
    } else if (system is MultiObjectSystem) {
      return _generateMultiObjectSystemWidget(system);
    }

    return null;
  }

  Widget _generateSingleObjectSystemWidget(
      SingleObjectSystem singleObjectSystem) {
    return Container(
      child: Row(
        children: [
          // TODO: Replace with icon
          Text('Single System'),

          // TODO: Replace with Stellar Object icon
          Text('Star, Planet or Moon'),

          // TODO: Replace with Column or Row, etc
          Text('Children')
        ],
      ),
    );
  }

  Widget _generateMultiObjectSystemWidget(MultiObjectSystem multiObjectSystem) {
    return Container(
      child: Row(
        children: [
          // TODO: Replace with icon
          Text('Single System'),

          // TODO: Replace with Stellar Object icon
          Text('Star, Planet or Moon'),

          // TODO: Replace with Column or Row, etc
          Text('Children')
        ],
      ),
    );
  }
}
