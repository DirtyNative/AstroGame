import 'package:astrogame_app/models/buildings/building.dart';
import 'package:astrogame_app/models/finished_technologies/finished_technology.dart';

class BuildingDetailBag {
  Building building;
  FinishedTechnology? finishedTechnology;

  BuildingDetailBag(this.building, this.finishedTechnology);
}
