import 'package:astrogame_app/communications/converters/guid_converter.dart';
import 'package:json_annotation/json_annotation.dart';
import 'building.dart';
import 'package:astrogame_app/models/buildings/building_cost.dart';
import 'package:astrogame_app/models/buildings/input_resource.dart';
import 'package:astrogame_app/models/buildings/output_resource.dart';
import 'package:astrogame_app/models/enums/stellar_object_type.dart';

part 'storage_building.g.dart';

@GuidConverter()
@JsonSerializable()
class StorageBuilding extends Building {
  StorageBuilding();

  factory StorageBuilding.fromJson(Map<String, dynamic> json) => _$StorageBuildingFromJson(json);
  Map<String, dynamic> toJson() => _$StorageBuildingToJson(this);
}
