import 'package:astrogame_app/converters/guid_converter.dart';
import 'package:astrogame_app/models/resources/resource.dart';
import 'package:astrogame_app/models/stellar/base_types/stellar_object.dart';
import 'package:flutter_guid/flutter_guid.dart';
import 'package:json_annotation/json_annotation.dart';

part 'stellar_object_resource.g.dart';

@GuidConverter()
@JsonSerializable()
class StellarObjectResource {
  @JsonKey()
  Guid id;

  @JsonKey()
  Guid stellarObjectId;

  @JsonKey()
  Guid resourceId;

  @JsonKey()
  double multiplier;

  @JsonKey()
  StellarObject stellarObject;

  @JsonKey()
  Resource resource;

  StellarObjectResource(
    this.id,
    this.stellarObjectId,
    this.resourceId,
    this.multiplier,
    this.stellarObject,
    this.resource,
  );

  factory StellarObjectResource.fromJson(Map<String, dynamic> json) =>
      _$StellarObjectResourceFromJson(json);
  Map<String, dynamic> toJson() => _$StellarObjectResourceToJson(this);
}
