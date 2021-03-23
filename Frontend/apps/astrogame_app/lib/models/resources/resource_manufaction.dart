import 'package:astrogame_app/communications/converters/guid_converter.dart';
import 'package:astrogame_app/models/resources/input_resource.dart';
import 'package:astrogame_app/models/resources/material.dart';
import 'package:flutter_guid/flutter_guid.dart';
import 'package:json_annotation/json_annotation.dart';

part 'resource_manufaction.g.dart';

@GuidConverter()
@JsonSerializable()
class ResourceManufaction {
  @JsonKey()
  Guid id;

  @JsonKey()
  Guid outputMaterialId;

  @JsonKey()
  double outputValue;

  @JsonKey()
  Material outputMaterial;

  @JsonKey()
  List<InputResource> inputResources;

  ResourceManufaction(this.id, this.outputMaterialId, this.outputValue,
      this.outputMaterial, this.inputResources);

  factory ResourceManufaction.fromJson(Map<String, dynamic> json) =>
      _$ResourceManufactionFromJson(json);
  Map<String, dynamic> toJson() => _$ResourceManufactionToJson(this);
}
