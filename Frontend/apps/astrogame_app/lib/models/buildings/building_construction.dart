import 'package:astrogame_app/communications/converters/guid_converter.dart';
import 'package:astrogame_app/models/technologies/technology_upgrade.dart';
import 'package:flutter_guid/flutter_guid.dart';
import 'package:json_annotation/json_annotation.dart';

part 'building_construction.g.dart';

@GuidConverter()
@JsonSerializable()
class BuildingConstruction extends TechnologyUpgrade {
  Guid buildingChainId;
  Guid stellarObjectId;

  BuildingConstruction();

  factory BuildingConstruction.fromJson(Map<String, dynamic> json) =>
      _$BuildingConstructionFromJson(json);
  Map<String, dynamic> toJson() => _$BuildingConstructionToJson(this);
}
