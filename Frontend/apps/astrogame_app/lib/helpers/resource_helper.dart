import 'package:astrogame_app/models/buildings/building.dart';
import 'package:astrogame_app/models/buildings/building_cost.dart';
import 'package:astrogame_app/models/buildings/dynamic_building_cost.dart';
import 'package:astrogame_app/models/buildings/fixed_building_cost.dart';
import 'package:astrogame_app/models/researches/dynamic_research_cost.dart';
import 'package:astrogame_app/models/researches/one_time_research_cost.dart';
import 'package:astrogame_app/models/researches/research.dart';
import 'package:astrogame_app/models/researches/research_cost.dart';
import 'package:astrogame_app/models/resources/stored_resource.dart';
import 'package:injectable/injectable.dart';
import 'dart:math';

@injectable
class ResourceHelper {
  bool hasStoredResourcesToBuild(List<StoredResource> resources, Building building, int level) {
    if (resources == null || resources.length == 0) {
      return false;
    }

    for (int index = 0; index < building.buildingCosts.length; index++) {
      var buildingCost = building.buildingCosts[index];

      var amount = calculateConstructionAmount(buildingCost, level + 1);

      // Check if there are stored resources
      if (resources.any((element) => element.resourceId == buildingCost.resourceId) == false) {
        return false;
      }

      var storedResource = resources.firstWhere((element) => element.resourceId == buildingCost.resourceId);

      if (storedResource == null) {
        return false;
      }

      if (storedResource.amount < amount) {
        return false;
      }
    }

    return true;
  }

  bool hasStoredResourcesToStudy(List<StoredResource> resources, Research research, int level) {
    if (resources == null || resources.length == 0) {
      return false;
    }

    for (int index = 0; index < research.researchCosts.length; index++) {
      var researchCost = research.researchCosts[index];

      var amount = calculateStudyAmount(researchCost, level + 1);

      // Check if there are stored resources
      if (resources.any((element) => element.resourceId == researchCost.resourceId) == false) {
        return false;
      }

      var storedResource = resources.firstWhere((element) => element.resourceId == researchCost.resourceId);

      if (storedResource == null) {
        return false;
      }

      if (storedResource.amount < amount) {
        return false;
      }
    }

    return true;
  }

  double calculateConstructionAmount(BuildingCost buildingCost, int level) {
    if (buildingCost is DynamicBuildingCost) {
      return buildingCost.baseValue * pow(buildingCost.multiplier, level - 1);
    } else if (buildingCost is FixedBuildingCost) {
      return buildingCost.amount;
    }

    throw Exception('${buildingCost.runtimeType} is not implemented yet');
  }

  double calculateStudyAmount(ResearchCost researchCost, int level) {
    if (researchCost is DynamicResearchCost) {
      return researchCost.baseValue * pow(researchCost.multiplier, level - 1);
    } else if (researchCost is OneTimeResearchCost) {
      return researchCost.amount;
    }

    throw Exception('${researchCost.runtimeType} is not implemented yet');
  }
}
