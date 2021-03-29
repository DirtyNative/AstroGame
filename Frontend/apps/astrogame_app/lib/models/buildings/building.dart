import 'package:astrogame_app/communications/converters/guid_converter.dart';
import 'package:astrogame_app/models/enums/stellar_object_type.dart';
import 'package:flutter_guid/flutter_guid.dart';
import 'package:json_annotation/json_annotation.dart';

import 'building_cost.dart';
import 'input_resource.dart';
import 'output_resource.dart';

part 'building.g.dart';

@GuidConverter()
@JsonSerializable()
class Building {
  Guid id;
  String name;
  String description;
  String assetName;

  int order;

  StellarObjectType buildableOn;

  List<BuildingCost> buildingCosts;
  List<InputResource> inputResources;
  List<OutputResource> outputResource;

  Building();

  factory Building.fromJson(Map<String, dynamic> json) =>
      _$BuildingFromJson(json);
  Map<String, dynamic> toJson() => _$BuildingToJson(this);
}
