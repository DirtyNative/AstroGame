import 'package:astrogame_app/communications/converters/building_converter.dart';
import 'package:astrogame_app/communications/converters/guid_converter.dart';
import 'package:astrogame_app/models/base_types/technology.dart';
import 'package:astrogame_app/models/enums/building_type.dart';
import 'package:astrogame_app/models/enums/stellar_object_type.dart';

import 'building_cost.dart';
import 'input_resource.dart';
import 'output_resource.dart';

@GuidConverter()
abstract class Building extends Technology {
  String name;
  String description;
  String assetName;
  BuildingType buildingType;

  int order;

  StellarObjectType buildableOn;

  List<BuildingCost> buildingCosts;
  List<InputResource> inputResources;
  List<OutputResource> outputResource;

  Building();

  factory Building.fromJson(Map<String, dynamic> json) =>
      BuildingConverter().fromJson(json);
}
