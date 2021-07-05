import 'package:astrogame_app/models/buildings/building.dart';
import 'package:astrogame_app/models/buildings/dynamic_building_cost.dart';
import 'package:astrogame_app/models/buildings/fixed_building_cost.dart';
import 'package:astrogame_app/models/researches/dynamic_research_cost.dart';
import 'package:astrogame_app/models/researches/one_time_research_cost.dart';
import 'package:astrogame_app/models/researches/research.dart';
import 'package:astrogame_app/models/resources/stored_resource.dart';
import 'package:astrogame_app/models/technologies/technology_cost.dart';
import 'package:injectable/injectable.dart';
import 'dart:math';

@injectable
class ResourceHelper {
  bool hasStoredResourcesToBuild(
      List<StoredResource> resources, Building building, int level) {
    if (resources == null || resources.length == 0) {
      return false;
    }

    for (int index = 0; index < building.technologyCosts.length; index++) {
      var buildingCost = building.technologyCosts[index];

      var amount = calculateConstructionAmount(buildingCost, level + 1);

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

  bool hasStoredResourcesToStudy(
      List<StoredResource> resources, Research research, int level) {
    if (resources == null || resources.length == 0) {
      return false;
    }

    for (int index = 0; index < research.technologyCosts.length; index++) {
      var researchCost = research.technologyCosts[index];

      var amount = calculateStudyAmount(researchCost, level + 1);

      // Check if there are stored resources
      if (resources.any(
              (element) => element.resourceId == researchCost.resourceId) ==
          false) {
        return false;
      }

      var storedResource = resources.firstWhere(
          (element) => element.resourceId == researchCost.resourceId);

      if (storedResource == null) {
        return false;
      }

      if (storedResource.amount < amount) {
        return false;
      }
    }

    return true;
  }

  double calculateConstructionAmount(TechnologyCost technologyCost, int level) {
    if (technologyCost is DynamicBuildingCost) {
      return technologyCost.baseValue *
          pow(technologyCost.multiplier, level - 1);
    } else if (technologyCost is FixedBuildingCost) {
      return technologyCost.amount;
    }

    throw Exception('${technologyCost.runtimeType} is not implemented yet');
  }

  double calculateStudyAmount(TechnologyCost technologyCost, int level) {
    if (technologyCost is DynamicResearchCost) {
      return technologyCost.baseValue *
          pow(technologyCost.multiplier, level - 1);
    } else if (technologyCost is OneTimeResearchCost) {
      return technologyCost.amount;
    }

    throw Exception('${technologyCost.runtimeType} is not implemented yet');
  }
}
