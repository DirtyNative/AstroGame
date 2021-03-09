import 'package:astrogame_app/converters/guid_converter.dart';
import 'package:astrogame_app/models/resources/resource.dart';
import 'package:astrogame_app/models/resources/resource_manufaction.dart';
import 'package:astrogame_app/models/resources/stellar_object_resource.dart';
import 'package:flutter_guid/flutter_guid.dart';
import 'package:json_annotation/json_annotation.dart';
import 'material_type.dart';

part 'material.g.dart';

@GuidConverter()
@JsonSerializable()
class Material extends Resource {
  @JsonKey()
  MaterialType type;

  @JsonKey()
  Guid manufactionId;

  @JsonKey()
  ResourceManufaction manufaction;

  Material(
    Guid id,
    String name,
    int naturalOccurrenceWeight,
    List<StellarObjectResource> stellarObjectResources,
    this.type,
    this.manufactionId,
    this.manufaction,
  ) : super(
          id,
          name,
          naturalOccurrenceWeight,
          stellarObjectResources,
        );

  factory Material.fromJson(Map<String, dynamic> json) =>
      _$MaterialFromJson(json);
  Map<String, dynamic> toJson() => _$MaterialToJson(this);
}
