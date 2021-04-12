import 'package:astrogame_app/models/buildings/building.dart';
import 'package:astrogame_app/models/buildings/building_cost.dart';
import 'package:astrogame_app/models/resources/stored_resource.dart';
import 'package:injectable/injectable.dart';
import 'dart:math';

@injectable
class ResourceHelper {
  bool hasStoredResourcesToBuild(
      List<StoredResource> resources, Building building, int level) {
    if (resources == null || resources.length == 0) {
      return false;
    }

    for (int index = 0; index < building.buildingCosts.length; index++) {
      var buildingCost = building.buildingCosts[index];

      var amount = _calculateAmount(buildingCost, level + 1);

      // Check if there are stored resources
      if (resources.any(
              (element) => element.resourceId == buildingCost.resourceId) ==
          false) {
        return false;
      }

      var storedResource = resources.firstWhere(
          (element) => element.resourceId == buildingCost.resourceId);

      if (storedResource == null) {
        return false;
      }

      if (storedResource.amount < amount) {
        return false;
      }
    }

    return true;
  }

  double _calculateAmount(BuildingCost buildingCost, int level) {
    return buildingCost.baseValue * pow(buildingCost.multiplier, level - 1);
  }
}
