import 'package:astrogame_app/communications/converters/guid_converter.dart';
import 'package:flutter_guid/flutter_guid.dart';
import 'package:json_annotation/json_annotation.dart';

part 'building_construction.g.dart';

@GuidConverter()
@JsonSerializable()
class BuildingConstruction {
  Guid id;
  Guid buildingChainId;
  Guid buildingId;
  Guid stellarObjectId;
  DateTime startTime;
  DateTime endTime;

  String hangdireJobId;

  BuildingConstruction();

  factory BuildingConstruction.fromJson(Map<String, dynamic> json) =>
      _$BuildingConstructionFromJson(json);
  Map<String, dynamic> toJson() => _$BuildingConstructionToJson(this);
}
