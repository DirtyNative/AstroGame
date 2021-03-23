import 'package:astrogame_app/communications/converters/guid_converter.dart';
import 'package:astrogame_app/models/resources/resource_manufaction.dart';
import 'package:flutter_guid/flutter_guid.dart';
import 'package:json_annotation/json_annotation.dart';

part 'input_resource.g.dart';

@GuidConverter()
@JsonSerializable()
class InputResource {
  @JsonKey()
  Guid id;

  @JsonKey()
  Guid resourceId;

  @JsonKey()
  Guid outputMaterialId;

  @JsonKey()
  double inputValue;

  //@JsonKey()
  //Resource input;

  @JsonKey()
  ResourceManufaction output;

  InputResource(
    this.id,
    this.resourceId,
    this.outputMaterialId,
    this.inputValue,
    //this.input,
    this.output,
  );

  factory InputResource.fromJson(Map<String, dynamic> json) =>
      _$InputResourceFromJson(json);
  Map<String, dynamic> toJson() => _$InputResourceToJson(this);
}
