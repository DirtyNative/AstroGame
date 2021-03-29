import 'package:astrogame_app/communications/converters/guid_converter.dart';
import 'package:astrogame_app/models/resources/resource.dart';
import 'package:astrogame_app/models/resources/stellar_object_resource.dart';
import 'package:json_annotation/json_annotation.dart';
import 'material_type.dart';

part 'material.g.dart';

@GuidConverter()
@JsonSerializable()
class Material extends Resource {
  @JsonKey()
  MaterialType type;

  Material();

  factory Material.fromJson(Map<String, dynamic> json) =>
      _$MaterialFromJson(json);
  Map<String, dynamic> toJson() => _$MaterialToJson(this);
}
