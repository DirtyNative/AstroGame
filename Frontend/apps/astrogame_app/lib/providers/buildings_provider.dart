import 'package:astrogame_app/models/buildings/building.dart';
import 'package:injectable/injectable.dart';

@singleton
class BuildingsProvider {
  List<Building> _buildings;

  List<Building> getBuildings() => _buildings;
  void setBuildings(List<Building> val) => _buildings = val;
}
