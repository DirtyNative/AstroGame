import 'package:astrogame_app/communications/converters/guid_converter.dart';
import 'package:astrogame_app/models/buildings/resource_amount.dart';
import 'package:astrogame_app/models/technologies/technology_value.dart';
import 'package:flutter_guid/flutter_guid.dart';
import 'package:json_annotation/json_annotation.dart';

part 'building_value.g.dart';

@GuidConverter()
@JsonSerializable()
class BuildingValue extends TechnologyValue {
  Guid buildingId;

  List<ResourceAmount> buildingConsumptions;
  List<ResourceAmount> buildingProductions;

  BuildingValue();

  factory BuildingValue.fromJson(Map<String, dynamic> json) =>
      _$BuildingValueFromJson(json);
  Map<String, dynamic> toJson() => _$BuildingValueToJson(this);
}
